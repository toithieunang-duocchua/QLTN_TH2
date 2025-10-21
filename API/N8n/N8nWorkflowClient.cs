using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace QLTN.API.N8n
{
    /// <summary>
    /// HTTP client wrapper for n8n workflows that handle verification code generation and validation.
    /// </summary>
    public sealed class N8nWorkflowClient : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly N8nOptions options;
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        public N8nWorkflowClient()
            : this(N8nOptions.FromConfiguration(), CreateDefaultHttpClient())
        {
        }

        public N8nWorkflowClient(N8nOptions options, HttpClient httpClient)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public bool IsConfigured => options.IsEnabled;
        public bool SupportsManagedVerification => options.SupportsManagedWorkflow;

        public async Task<N8nVerificationRequestResult> RequestVerificationCodeAsync(string email, CancellationToken cancellationToken = default)
        {
            EnsureManagedWorkflowConfigured();

            Dictionary<string, object> payload = new Dictionary<string, object>
            {
                ["email"] = email,
                ["requestedAtUtc"] = DateTime.UtcNow
            };

            Dictionary<string, object> response = await PostAsync(options.RequestEndpoint, payload, cancellationToken).ConfigureAwait(false);
            return N8nVerificationRequestResult.FromDictionary(response);
        }

        public async Task<N8nVerificationCheckResult> VerifyCodeAsync(string email, string code, CancellationToken cancellationToken = default)
        {
            EnsureManagedWorkflowConfigured();

            Dictionary<string, object> payload = new Dictionary<string, object>
            {
                ["email"] = email,
                ["code"] = code,
                ["verifiedAtUtc"] = DateTime.UtcNow
            };

            Dictionary<string, object> response = await PostAsync(options.VerifyEndpoint, payload, cancellationToken).ConfigureAwait(false);
            return N8nVerificationCheckResult.FromDictionary(response);
        }

        private async Task<Dictionary<string, object>> PostAsync(Uri endpoint, Dictionary<string, object> payload, CancellationToken cancellationToken)
        {
            string json = serializer.Serialize(payload);

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                if (!string.IsNullOrEmpty(options.ApiKey))
                {
                    request.Headers.Add(options.ApiKeyHeaderName, options.ApiKey);
                }

                using (HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException($"G\u1ecdi workflow n8n th\u1ea5t b\u1ea1i: {(int)response.StatusCode} {response.ReasonPhrase}. Ph\u1ea3n h\u1ed3i: {responseBody}");
                    }

                    if (string.IsNullOrWhiteSpace(responseBody))
                    {
                        return new Dictionary<string, object>();
                    }

                    Dictionary<string, object> dictionary = serializer.Deserialize<Dictionary<string, object>>(responseBody);
                    return dictionary ?? new Dictionary<string, object>();
                }
            }
        }

        private void EnsureManagedWorkflowConfigured()
        {
            if (!SupportsManagedVerification)
            {
                throw new InvalidOperationException("Ch\u01b0a c\u1ea5u h\u00ecnh endpoint n8n cho vi\u1ec7c sinh/ki\u1ec3m tra m\u00e3 x\u00e1c minh.");
            }
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }

        private static HttpClient CreateDefaultHttpClient()
        {
            return new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(15)
            };
        }
    }

    public sealed class N8nOptions
    {
        private N8nOptions(bool isEnabled, Uri requestEndpoint, Uri verifyEndpoint, string apiKey, string apiKeyHeaderName)
        {
            IsEnabled = isEnabled;
            RequestEndpoint = requestEndpoint;
            VerifyEndpoint = verifyEndpoint;
            ApiKey = apiKey;
            ApiKeyHeaderName = string.IsNullOrWhiteSpace(apiKeyHeaderName) ? "X-N8N-API-KEY" : apiKeyHeaderName.Trim();
        }

        public bool IsEnabled { get; }
        public Uri RequestEndpoint { get; }
        public Uri VerifyEndpoint { get; }
        public string ApiKey { get; }
        public string ApiKeyHeaderName { get; }
        public bool SupportsManagedWorkflow => RequestEndpoint != null && VerifyEndpoint != null;

        public static N8nOptions FromConfiguration()
        {
            string baseUrl = ConfigurationManager.AppSettings["N8nBaseUrl"];
            string requestPath = ConfigurationManager.AppSettings["N8nRequestVerificationPath"];
            string verifyPath = ConfigurationManager.AppSettings["N8nVerifyCodePath"];
            string apiKey = ConfigurationManager.AppSettings["N8nApiKey"];
            string apiKeyHeader = ConfigurationManager.AppSettings["N8nApiKeyHeader"];

            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(requestPath) || string.IsNullOrWhiteSpace(verifyPath))
            {
                return new N8nOptions(false, null, null, null, apiKeyHeader);
            }

            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out Uri baseUri))
            {
                throw new ConfigurationErrorsException("Gi\u00e1 tr\u1ecb N8nBaseUrl kh\u00f4ng h\u1ee3p l\u1ec7.");
            }

            Uri requestEndpoint = BuildEndpoint(baseUri, requestPath);
            Uri verifyEndpoint = BuildEndpoint(baseUri, verifyPath);

            return new N8nOptions(
                isEnabled: true,
                requestEndpoint: requestEndpoint,
                verifyEndpoint: verifyEndpoint,
                apiKey: string.IsNullOrWhiteSpace(apiKey) ? null : apiKey.Trim(),
                apiKeyHeaderName: apiKeyHeader);
        }

        private static Uri BuildEndpoint(Uri baseUri, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (Uri.TryCreate(path, UriKind.Absolute, out Uri absolute))
            {
                return absolute;
            }

            string relativePath = path.StartsWith("/", StringComparison.Ordinal)
                ? path.Substring(1)
                : path;

            return new Uri(baseUri, relativePath);
        }
    }

    public sealed class N8nVerificationRequestResult
    {
        private N8nVerificationRequestResult(bool success, string message, DateTime? expiresAtUtc, int? expiresInSeconds)
        {
            Success = success;
            Message = message;
            ExpiresAtUtc = expiresAtUtc;
            ExpiresInSeconds = expiresInSeconds;
        }

        public bool Success { get; }
        public string Message { get; }
        public DateTime? ExpiresAtUtc { get; }
        public int? ExpiresInSeconds { get; }

        public static N8nVerificationRequestResult FromDictionary(Dictionary<string, object> data)
        {
            bool success = N8nResponseHelper.TryGetBool(data, "success") ?? true;
            string message = N8nResponseHelper.TryGetString(data, "message");

            DateTime? expiresAt = N8nResponseHelper.TryGetDateTime(data, "expiresAtUtc")
                                  ?? N8nResponseHelper.TryGetDateTime(data, "expiresAt");
            int? expiresInSeconds = N8nResponseHelper.TryGetInt(data, "expiresInSeconds");

            return new N8nVerificationRequestResult(success, message, expiresAt, expiresInSeconds);
        }
    }

    public sealed class N8nVerificationCheckResult
    {
        private N8nVerificationCheckResult(N8nVerificationState state, string message, DateTime? expiresAtUtc, int? remainingSeconds)
        {
            State = state;
            Message = message;
            ExpiresAtUtc = expiresAtUtc;
            RemainingSeconds = remainingSeconds;
        }

        public N8nVerificationState State { get; }
        public string Message { get; }
        public DateTime? ExpiresAtUtc { get; }
        public int? RemainingSeconds { get; }

        public static N8nVerificationCheckResult FromDictionary(Dictionary<string, object> data)
        {
            string statusValue = N8nResponseHelper.TryGetString(data, "status")
                                 ?? N8nResponseHelper.TryGetString(data, "state");
            string message = N8nResponseHelper.TryGetString(data, "message");
            DateTime? expiresAt = N8nResponseHelper.TryGetDateTime(data, "expiresAtUtc")
                                  ?? N8nResponseHelper.TryGetDateTime(data, "expiresAt");
            int? remainingSeconds = N8nResponseHelper.TryGetInt(data, "remainingSeconds");

            N8nVerificationState state = MapState(statusValue);

            return new N8nVerificationCheckResult(state, message, expiresAt, remainingSeconds);
        }

        private static N8nVerificationState MapState(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return N8nVerificationState.Unknown;
            }

            switch (status.Trim().ToLowerInvariant())
            {
                case "success":
                case "verified":
                case "validated":
                    return N8nVerificationState.Success;
                case "expired":
                    return N8nVerificationState.Expired;
                case "incorrect":
                case "invalid":
                case "mismatch":
                    return N8nVerificationState.Incorrect;
                case "not_requested":
                case "notrequested":
                case "not_found":
                case "missing":
                    return N8nVerificationState.NotRequested;
                default:
                    return N8nVerificationState.Unknown;
            }
        }
    }

    public enum N8nVerificationState
    {
        Success,
        Expired,
        Incorrect,
        NotRequested,
        Unknown
    }

    internal static class N8nResponseHelper
    {
        public static string TryGetString(IDictionary<string, object> data, string key)
        {
            if (data == null || !data.TryGetValue(key, out object raw) || raw == null)
            {
                return null;
            }

            return raw.ToString();
        }

        public static bool? TryGetBool(IDictionary<string, object> data, string key)
        {
            if (data == null || !data.TryGetValue(key, out object raw) || raw == null)
            {
                return null;
            }

            if (raw is bool boolean)
            {
                return boolean;
            }

            if (bool.TryParse(raw.ToString(), out bool parsed))
            {
                return parsed;
            }

            return null;
        }

        public static int? TryGetInt(IDictionary<string, object> data, string key)
        {
            if (data == null || !data.TryGetValue(key, out object raw) || raw == null)
            {
                return null;
            }

            if (raw is int value)
            {
                return value;
            }

            if (int.TryParse(raw.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsed))
            {
                return parsed;
            }

            return null;
        }

        public static DateTime? TryGetDateTime(IDictionary<string, object> data, string key)
        {
            string value = TryGetString(data, key);
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out DateTime parsed))
            {
                return parsed.ToUniversalTime();
            }

            return null;
        }
    }
}
