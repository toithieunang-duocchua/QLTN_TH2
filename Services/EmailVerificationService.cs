using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QLTN.API.Google;
using QLTN.API.N8n;

namespace QLTN.Services
{
    public class EmailVerificationService
    {
        private static readonly TimeSpan CodeLifetime = TimeSpan.FromMinutes(5);
        private static readonly TimeSpan ResendCooldown = TimeSpan.FromSeconds(60);
        private static readonly ConcurrentDictionary<string, VerificationTicket> Tickets =
            new ConcurrentDictionary<string, VerificationTicket>(StringComparer.OrdinalIgnoreCase);

        private readonly GmailApiClient gmailClient;
        private readonly N8nWorkflowClient n8nClient;
        private readonly bool useN8nManagedWorkflow;

        public EmailVerificationService()
        {
            n8nClient = new N8nWorkflowClient();
            useN8nManagedWorkflow = n8nClient.SupportsManagedVerification;

            if (!useN8nManagedWorkflow)
            {
                gmailClient = new GmailApiClient();
            }
        }

        public async Task SendVerificationCodeAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email kh\u00f4ng h\u1ee3p l\u1ec7.", nameof(email));
            }

            string normalizedEmail = email.Trim();
            DateTime utcNow = DateTime.UtcNow;

            if (useN8nManagedWorkflow)
            {
                N8nVerificationRequestResult result = await n8nClient.RequestVerificationCodeAsync(normalizedEmail).ConfigureAwait(false);
                if (!result.Success)
                {
                    string message = string.IsNullOrWhiteSpace(result.Message)
                        ? "Kh\u00f4ng th\u1ec3 y\u00eau c\u1ea7u m\u00e3 x\u00e1c minh t\u1eeb n8n."
                        : result.Message;
                    throw new InvalidOperationException(message);
                }

                return;
            }

            if (Tickets.TryGetValue(normalizedEmail, out VerificationTicket existingTicket))
            {
                TimeSpan elapsed = utcNow - existingTicket.LastSentUtc;
                if (elapsed < ResendCooldown)
                {
                    double seconds = Math.Ceiling((ResendCooldown - elapsed).TotalSeconds);
                    throw new InvalidOperationException($"Vui l\u00f2ng \u0111\u1ee3i {seconds:0} gi\u00e2y tr\u01b0\u1edbc khi y\u00eau c\u1ea7u m\u00e3 m\u1edbi.");
                }
            }

            string code = GenerateCode();
            VerificationTicket newTicket = new VerificationTicket(code, utcNow.Add(CodeLifetime), utcNow);
            Tickets[normalizedEmail] = newTicket;

            await SendEmailAsync(normalizedEmail, code);
        }

        public async Task ResendCodeAsync(string email)
        {
            await SendVerificationCodeAsync(email);
        }

        public async Task<VerificationStatus> VerifyCodeAsync(string email, string code)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return VerificationStatus.NotRequested;
            }

            string normalizedEmail = email.Trim();

            if (useN8nManagedWorkflow)
            {
                N8nVerificationCheckResult result = await n8nClient.VerifyCodeAsync(normalizedEmail, code).ConfigureAwait(false);
                switch (result.State)
                {
                    case N8nVerificationState.Success:
                        return VerificationStatus.Success;
                    case N8nVerificationState.Expired:
                        return VerificationStatus.Expired;
                    case N8nVerificationState.NotRequested:
                        return VerificationStatus.NotRequested;
                    case N8nVerificationState.Incorrect:
                        return VerificationStatus.Incorrect;
                    default:
                        if (!string.IsNullOrWhiteSpace(result.Message))
                        {
                            throw new InvalidOperationException(result.Message);
                        }

                        return VerificationStatus.Incorrect;
                }
            }

            if (!Tickets.TryGetValue(normalizedEmail, out VerificationTicket ticket))
            {
                return VerificationStatus.NotRequested;
            }

            DateTime utcNow = DateTime.UtcNow;
            if (ticket.ExpiresAtUtc <= utcNow)
            {
                Tickets.TryRemove(normalizedEmail, out _);
                return VerificationStatus.Expired;
            }

            if (!string.Equals(ticket.Code, code, StringComparison.Ordinal))
            {
                return VerificationStatus.Incorrect;
            }

            Tickets.TryRemove(normalizedEmail, out _);
            return VerificationStatus.Success;
        }

        public TimeSpan? GetRemainingLifetime(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            string normalizedEmail = email.Trim();

            if (!Tickets.TryGetValue(normalizedEmail, out VerificationTicket ticket))
            {
                return null;
            }

            TimeSpan remaining = ticket.ExpiresAtUtc - DateTime.UtcNow;
            return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
        }

        private async Task SendEmailAsync(string recipient, string code)
        {
            if (gmailClient == null)
            {
                throw new InvalidOperationException("Ch\u01b0a c\u1ea5u h\u00ecnh Gmail API cho ch\u1ebf \u0111\u1ed9 g\u1eedi email n\u1ed9i b\u1ed9.");
            }

            string subject = "M\u00e3 x\u00e1c th\u1ef1c \u0111\u1eb7t l\u1ea1i m\u1eadt kh\u1ea9u";
            string body = BuildBody(code);
            await gmailClient.SendPlainTextAsync(recipient, subject, body).ConfigureAwait(false);
        }

        private static string BuildBody(string code)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Xin ch\u00e0o,");
            builder.AppendLine();
            builder.AppendLine("B\u1ea1n v\u1eeba y\u00eau c\u1ea7u \u0111\u1eb7t l\u1ea1i m\u1eadt kh\u1ea9u tr\u00ean h\u1ec7 th\u1ed1ng QLTN.");
            builder.AppendLine("Vui l\u00f2ng s\u1eed d\u1ee5ng m\u00e3 x\u00e1c th\u1ef1c sau \u0111\u1ec3 ti\u1ebfp t\u1ee5c:");
            builder.AppendLine();
            builder.AppendLine($"    M\u00e3 x\u00e1c th\u1ef1c: {code}");
            builder.AppendLine();
            builder.AppendLine("M\u00e3 s\u1ebd h\u1ebft h\u1ea1n sau 5 ph\u00fat k\u1ec3 t\u1eeb khi email \u0111\u01b0\u1ee3c g\u1eedi.");
            builder.AppendLine("N\u1ebfu b\u1ea1n kh\u00f4ng ph\u1ea3i l\u00e0 ng\u01b0\u1eddi y\u00eau c\u1ea7u, h\u00e3y b\u1ecf qua email n\u00e0y.");
            builder.AppendLine();
            builder.AppendLine("Tr\u00e2n tr\u1ecdng,");
            builder.Append("\u0110\u1ed9i ng\u0169 QLTN");
            return builder.ToString();
        }

        private static string GenerateCode()
        {
            byte[] buffer = new byte[4];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }

            int value = BitConverter.ToInt32(buffer, 0);
            if (value < 0)
            {
                value = -value;
            }

            int code = value % 900000 + 100000;
            return code.ToString("D6", CultureInfo.InvariantCulture);
        }

        private class VerificationTicket
        {
            public VerificationTicket(string code, DateTime expiresAtUtc, DateTime lastSentUtc)
            {
                Code = code;
                ExpiresAtUtc = expiresAtUtc;
                LastSentUtc = lastSentUtc;
            }

            public string Code { get; }
            public DateTime ExpiresAtUtc { get; }
            public DateTime LastSentUtc { get; }
        }

        public enum VerificationStatus
        {
            Success,
            NotRequested,
            Expired,
            Incorrect
        }
    }
}
