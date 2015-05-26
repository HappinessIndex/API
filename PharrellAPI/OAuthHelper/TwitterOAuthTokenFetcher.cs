using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OAuthHelper
{
    public class TwitterOAuthTokenFetcher
    {
        private OAuthBasicAuthenticationHeader _authHeader;

        public TwitterOAuthTokenFetcher(OAuthBasicAuthenticationHeader authHeader)
        {
            this._authHeader = authHeader;
        }

        public async Task<TwitterAuthenticationResponse> ObtainToken()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.twitter.com");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", _authHeader.GetEncodedHeader());
                HttpContent postContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                });

                HttpResponseMessage authResponse = client.PostAsync("oauth2/token", postContent).Result;
                if (authResponse.IsSuccessStatusCode)
                {
                    var token = new TwitterAuthenticationResponse();
                    string authContent = await authResponse.Content.ReadAsStringAsync();
                    JsonConvert.PopulateObject(authContent, token);
                    return token;
                }

                return null;
            }
        }
    }
}