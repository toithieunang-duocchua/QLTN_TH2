using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace QLTN.API.Google
{
    /// <summary>
    /// Handles OAuth refresh token flow for Google APIs. The desktop app stores a refresh token
    /// (received after the consent screen) and exchanges it for short lived access tokens on demand.
    /// </summary>
    public sealed class GoogleOAuthClient : IDisposable
    {
        private static readonly Uri TokenEndpoint = new Uri("https://oauth2.googleapis.com/token");
        private static readonly TimeSpan ClockSkew = TimeSpan.FromSeconds(30);

        private readonly GoogleOAuthOptions options;
        private readonly HttpClient httpClient;
        private GoogleAccessToken cachedToken;

        public GoogleOAuthClient()
            : this(GoogleOAuthOptions.FromConfiguration(), CreateDefaultHttpClient())
        {
        }

        public GoogleOAuthClient(GoogleOAuthOptions options, HttpClient httpClient)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Returns a valid access token, refreshing it if necessary.
        /// </summary>
        public async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            if (cachedToken != null && !cachedToken.IsExpired)
            {
                return cachedToken.AccessToken;
            }

            Dictionary<string, string> payload = new Dictionary<string, string>
            {
                ["client_id"] = options.ClientId,
                ["client_secret"] = options.ClientSecret,
                ["refresh_token"] = options.RefreshToken,
                ["grant_type"] = "refresh_token"
            };

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, TokenEndpoint))
            {
                request.Content = new FormUrlEncodedContent(payload);

                using (HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    string body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException($"Kh\u00f4ng th\u1ec3 l\u1ea5y access token t\u1eeb Google: {(int)response.StatusCode} {response.ReasonPhrase}. Ph\u1ea3n h\u1ed3i: {body}");
                    }

                    GoogleAccessToken token = GoogleAccessToken.FromJson(body);
                    cachedToken = token.WithSafetyMargin(ClockSkew);
                    return cachedToken.AccessToken;
                }
            }
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }

        private static HttpClient CreateDefaultHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                AllowAutoRedirect = true
            };

            return new HttpClient(handler, disposeHandler: true)
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
        }
    }

    public sealed class GoogleOAuthOptions
    {
        public GoogleOAuthOptions(string clientId, string clientSecret, string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ConfigurationErrorsException("Thi\u1ebfu c\u1ea5u h\u00ecnh GoogleClientId trong App.config.");
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new ConfigurationErrorsException("Thi\u1ebfu c\u1ea5u h\u00ecnh GoogleClientSecret trong App.config.");
            }

            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                throw new ConfigurationErrorsException("Thi\u1ebfu c\u1ea5u h\u00ecnh GoogleRefreshToken trong App.config.");
            }

            ClientId = clientId.Trim();
            ClientSecret = clientSecret.Trim();
            RefreshToken = refreshToken.Trim();
        }

        public string ClientId { get; }
        public string ClientSecret { get; }
        public string RefreshToken { get; }

        public static GoogleOAuthOptions FromConfiguration()
        {
            string clientId = ConfigurationManager.AppSettings["GoogleClientId"];
            string clientSecret = ConfigurationManager.AppSettings["GoogleClientSecret"];
            string refreshToken = ConfigurationManager.AppSettings["GoogleRefreshToken"];
            return new GoogleOAuthOptions(clientId, clientSecret, refreshToken);
        }
    }

    public sealed class GoogleAccessToken
    {
        private GoogleAccessToken(string accessToken, string tokenType, DateTime expiresAtUtc)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresAtUtc = expiresAtUtc;
        }

        public string AccessToken { get; }
        public string TokenType { get; }
        public DateTime ExpiresAtUtc { get; }

        public bool IsExpired => DateTime.UtcNow >= ExpiresAtUtc;

        public GoogleAccessToken WithSafetyMargin(TimeSpan margin)
        {
            DateTime adjusted = ExpiresAtUtc - margin;
            return new GoogleAccessToken(AccessToken, TokenType, adjusted);
        }

        public static GoogleAccessToken FromJson(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> payload = serializer.Deserialize<Dictionary<string, object>>(json);

            if (!payload.TryGetValue("access_token", out object accessTokenObj) || accessTokenObj == null)
            {
                throw new InvalidOperationException("Ph\u1ea3n h\u1ed3i t\u1eeb Google kh\u00f4ng c\u00f3 access_token.");
            }

            string accessToken = accessTokenObj.ToString();

            string tokenType = payload.TryGetValue("token_type", out object tokenTypeObj)
                ? tokenTypeObj?.ToString()
                : "Bearer";

            int expiresIn = payload.TryGetValue("expires_in", out object expiresInObj) && expiresInObj != null
                ? Convert.ToInt32(expiresInObj)
                : 3600;

            DateTime expiresAt = DateTime.UtcNow.AddSeconds(expiresIn);
            return new GoogleAccessToken(accessToken, tokenType, expiresAt);
        }
    }
}
