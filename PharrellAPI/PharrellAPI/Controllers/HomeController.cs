using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using PharrellAPI.Models;

namespace PharrellAPI.Controllers
{
    public class HomeController : Controller
    {
        public int sentimentValue(float confidence, string sentiment)
        {
            if (sentiment == "Positive")
            {
                if (confidence >= 90)
                {
                    return 9;
                }
                if (confidence >= 80)
                {
                    return 8;
                }
                if (confidence >= 70)
                {
                    return 7;
                }
                if (confidence >= 60)
                {
                    return 6;
                }
            }

            else if (sentiment == "Neutral")
            {
                return 5;
            }

            if (sentiment == "Negative")
            {
                if (confidence >= 90)
                {
                    return 1;
                }
                if (confidence >= 80)
                {
                    return 2;
                }
                if (confidence >= 70)
                {
                    return 3;
                }
                if (confidence >= 60)
                {
                    return 4;
                }
            }
            return 0;
        }

        public void SentimentCall()
        {
            HiDbContext db = new HiDbContext();
            var targeturi = "https://community-sentiment.p.mashape.com/text/";
            var client = new HttpClient();

            foreach (var tweet in db.Tweets)
            {
                HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("txt", tweet.Content),
            });
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                content.Headers.Add("X-Mashape-Key", "g482YWPyg5mshIeQkyGfhTJAPvt2p17khJgjsnnHQQag0P04Zm");

                var response = client.PostAsync(targeturi, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Sentiment respContent = response.Content.ReadAsAsync<Sentiment>().Result;
                    respContent.result.TweetId = tweet;
                    respContent.result.SentimentValue = sentimentValue(respContent.result.confidence, respContent.result.sentiment);
                    db.Results.Add(respContent.result);
                    
                }
            }

            db.SaveChanges();
        }
    }
}