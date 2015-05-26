using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OAuthHelper
{
    public class TwitterTweetFetcher
    {
        private TwitterAuthenticationResponse token;

        public TwitterTweetFetcher(TwitterAuthenticationResponse token)
        {
            this.token = token;
        }

        public async Task<TwitterSearchResponse> Search(decimal latitude, decimal longtitude, int radius,
            string resultType, int count)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.twitter.com");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", string.Format("{0} {1}", token.token_type, token.access_token));
                HttpResponseMessage getResponse =
                    await
                        client.GetAsync(string.Format(
                            "1.1/search/tweets.json?q=&geocode={0},{1},{2}km&result_type={3}&count={4}", longtitude, latitude, radius, resultType, count));

                if (getResponse.IsSuccessStatusCode)
                {
                    string getContent = await getResponse.Content.ReadAsStringAsync();
                    var tweets = new TwitterSearchResponse();
                    JsonConvert.PopulateObject(getContent, tweets);
                    return tweets;
                }

                return null;
            }
        }
    }
}