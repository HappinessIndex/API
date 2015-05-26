using System;
using System.Text;

namespace OAuthHelper
{
    public class OAuthBasicAuthenticationHeader
    {
        private string _apiKey;
        private string _apiSecret;

        public OAuthBasicAuthenticationHeader(string key, string secret)
        {
            this._apiKey = Uri.EscapeDataString(key);
            this._apiSecret = Uri.EscapeDataString(secret);
        }

        public string GetEncodedHeader()
        {
            string consumer = string.Format("{0}:{1}", _apiKey, _apiSecret);
            string encodedAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes(consumer));
            return string.Format("Basic {0}", encodedAuth);
        }
    }
}