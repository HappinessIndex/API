using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.Configuration;
using Tweetinvi;
using Tweetinvi.Core.Enum;

namespace SocialData.Plugins.Twitter
{
    public class Twitter
    {
        public IEnumerable<Tweet> FetchSocialData()
        {
            string accessToken = WebConfigurationManager.AppSettings["ACCESS_TOKEN"];
            string accessTokenSecret = WebConfigurationManager.AppSettings["ACCESS_TOKEN_SECRET"];
            string consumerKey = WebConfigurationManager.AppSettings["CONSUMER_KEY"];
            string consumerSecret = WebConfigurationManager.AppSettings["CONSUMER_SECRET"];
            
            TwitterCredentials.SetCredentials(accessToken, accessTokenSecret, consumerKey, consumerSecret);

            var searchParameter = Search.CreateTweetSearchParameter("");
            searchParameter.SetGeoCode(174.77624,-41.28646, 35, DistanceMeasure.Kilometers);
            searchParameter.Lang = Language.English;
            searchParameter.MaximumNumberOfResults = 20000;
            var tweets = Search.SearchTweets(searchParameter);

            IEnumerable<Tweet> allTweets = tweets.Select(tweet => new Tweet()
            {
                Content = tweet.Text,
                Point = DbGeography.FromText(String.Format("POINT({0} {1})", tweet.Coordinates.Longitude, tweet.Coordinates.Latitude)),
                TweetId = tweet.Id
            });
            
            return allTweets;
        }
    }
}