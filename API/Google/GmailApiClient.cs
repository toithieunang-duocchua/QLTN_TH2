using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QLTN.API.Google
{
    /// <summary>
    /// Lightweight Gmail API client that sends simple plaintext emails by leveraging an OAuth refresh token.
    /// </summary>
    public sealed class GmailApiClient : IDisposable
    {
        private static readonly Uri SendEndpoint = new Uri("https://gmail.googleapis.com/gmail/v1/users/me/messages/send");

        private readonly GoogleOAuthClient oauthClient;
        private readonly GmailSenderOptions options;
        private readonly HttpClient httpClient;

        public GmailApiClient()
            : this(new GoogleOAuthClient(), GmailSenderOptions.FromConfiguration(), CreateDefaultHttpClient())
        {
        }

        public GmailApiClient(GoogleOAuthClient oauthClient, GmailSenderOptions options, HttpClient httpClient)
        {
            this.oauthClient = oauthClient ?? throw new ArgumentNullException(nameof(oauthClient));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task SendPlainTextAsync(string recipientEmail, string subject, string body, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(recipientEmail))
            {
                throw new ArgumentException("Thi\u1ebfu email ng\u01b0\u1eddi nh\u1eadn.", nameof(recipientEmail));
            }

            string rawMessage = CreateRawMimeMessage(recipientEmail.Trim(), subject ?? string.Empty, body ?? string.Empty);
            string jsonPayload = "{\"raw\":\"" + Base64UrlEncode(rawMessage) + "\"}";

            string accessToken = await oauthClient.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, SendEndpoint))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new InvalidOperationException($"G\u1eedi email qua Gmail API th\u1ea5t b\u1ea1i: {(int)response.StatusCode} {response.ReasonPhrase}. Ph\u1ea3n h\u1ed3i: {responseBody}");
                    }
                }
            }
        }

        private string CreateRawMimeMessage(string recipientEmail, string subject, string body)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("From: ").Append(options.GetFormattedFromAddress()).Append("\r\n");
            builder.Append("To: ").Append(recipientEmail).Append("\r\n");
            builder.Append("Subject: ").Append(subject).Append("\r\n");
            builder.Append("Content-Type: text/plain; charset=utf-8\r\n");
            builder.Append("Content-Transfer-Encoding: quoted-printable\r\n");
            builder.Append("\r\n");
            builder.Append(body);
            return builder.ToString();
        }

        private static string Base64UrlEncode(string value)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(value);
            string base64 = Convert.ToBase64String(inputBytes);
            return base64.Replace("+", "-").Replace("/", "_").TrimEnd('=');
        }

        private static HttpClient CreateDefaultHttpClient()
        {
            return new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public void Dispose()
        {
            httpClient?.Dispose();
            oauthClient?.Dispose();
        }
    }

    public sealed class GmailSenderOptions
    {
        public GmailSenderOptions(string senderEmail, string senderDisplayName)
        {
            if (string.IsNullOrWhiteSpace(senderEmail))
            {
                throw new ConfigurationErrorsException("Thi\u1ebfu c\u1ea5u h\u00ecnh GoogleSenderEmail trong App.config.");
            }

            SenderEmail = senderEmail.Trim();
            SenderDisplayName = string.IsNullOrWhiteSpace(senderDisplayName)
                ? SenderEmail
                : senderDisplayName.Trim();
        }

        public string SenderEmail { get; }
        public string SenderDisplayName { get; }

        public static GmailSenderOptions FromConfiguration()
        {
            string senderEmail = ConfigurationManager.AppSettings["GoogleSenderEmail"];
            string displayName = ConfigurationManager.AppSettings["GoogleSenderName"];
            return new GmailSenderOptions(senderEmail, displayName);
        }

        public string GetFormattedFromAddress()
        {
            if (string.Equals(SenderEmail, SenderDisplayName, StringComparison.OrdinalIgnoreCase))
            {
                return SenderEmail;
            }

            return $"{SenderDisplayName} <{SenderEmail}>";
        }
    }
}
