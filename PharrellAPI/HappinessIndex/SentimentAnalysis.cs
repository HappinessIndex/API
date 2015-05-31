using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PharrellAPI;
using SocialData.Plugins.Twitter;

namespace HappinessIndex
{
    public class SentimentAnalysis
    {
        public int CalculateHappinessIndex(float confidence, string sentiment)
        {
            int tens = (int)Math.Floor(confidence/10);

            switch (sentiment)
            {
                case "Positive":
                    return tens;

                case "Negative":
                    return 10 - tens;

                default:
                    return 5;
            }
        }

        public async void SentimentCall(Tweet tweet)
        {
            HiDbContext db = new HiDbContext();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://community-sentiment.p.mashape.com");
                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("txt", tweet.Content),
                });
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                content.Headers.Add("X-Mashape-Key", "g482YWPyg5mshIeQkyGfhTJAPvt2p17khJgjsnnHQQag0P04Zm");

                HttpResponseMessage response = await client.PostAsync("text", content);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    SentimentAnalysisResponse sentimentAnalysis = new SentimentAnalysisResponse();
                    JsonConvert.PopulateObject(json, sentimentAnalysis);
                    tweet.HappinessIndex = CalculateHappinessIndex(sentimentAnalysis.result.confidence, tweet.Content);
                }
            }

            db.SaveChanges();
        }
    }
}