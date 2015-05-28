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
        public void SentimentCall()
        {
            HiDbContext db = new HiDbContext();
            var targeturi = "https://community-sentiment.p.mashape.com/text/";
            var client = new HttpClient();

            foreach (var tweet in db.Tweets.Take(30))
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
                    db.Results.Add(respContent.result);
                    
                }
            }

            db.SaveChanges();
        }
    }
}