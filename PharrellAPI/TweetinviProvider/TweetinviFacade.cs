using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using InterfacesAndPOCOs;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweet = InterfacesAndPOCOs.Tweet;


namespace TweetinviProvider
{
    public class TweetinviFacade : ITwitterFacade
    {
        public IEnumerable<Tweet> GetTweets()
        {
            string accessToken = WebConfigurationManager.AppSettings["ACCESS_TOKEN"];
            string accessTokenSecret = WebConfigurationManager.AppSettings["ACCESS_TOKEN_SECRET"];
            string consumerKey = WebConfigurationManager.AppSettings["CONSUMER_KEY"];
            string consumerSecret = WebConfigurationManager.AppSettings["CONSUMER_SECRET"];
            
            TwitterCredentials.SetCredentials(accessToken, accessTokenSecret, consumerKey, consumerSecret);

            var searchParameter = Search.CreateTweetSearchParameter("");
            searchParameter.SetGeoCode(174.77624,-41.28646, 35, DistanceMeasure.Kilometers);
            searchParameter.Lang = Language.English;
            searchParameter.MaximumNumberOfResults = 5;
            var tweets = Search.SearchTweets(searchParameter);
            
            IEnumerable<Tweet> allTweets = tweets.Select(tweet => new Tweet()
            {
                Content = tweet.Text,
                UserName = tweet.Creator.ScreenName,
                Lat = tweet.Coordinates.Latitude,
                Long = tweet.Coordinates.Longitude
            });
            return allTweets;
        }
    }
}
