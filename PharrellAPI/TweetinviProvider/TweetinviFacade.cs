using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesAndPOCOs;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Models.Parameters;
using Tweet = InterfacesAndPOCOs.Tweet;

namespace TweetinviProvider
{
    public class TweetinviFacade : ITwitterFacade
    {
        public Tweet GetATweet()
        {



            TwitterCredentials.SetCredentials("2921127883-M9T6lcDuQKf7WxQvnXbvrk2x0NNR27oiWXs7CLq", "3wNUKdx43Uj2GXrtmfDLkGsiq5vL03VTnAWvuNfMWAy5M", "crJtctea5xVbgcGN9q1NF452h", "huPobN7kdOwWzOxwjxPNlPAFM3rdfq3QGCisUT9OC0FRvxYSND");
//            var user = User.GetLoggedUser();
            //var user = User.GetUserFromScreenName("iaink23");
            //ITweet tweet = user.Timeline.First();
            //Debug.WriteLine(user.ScreenName);
            //Debug.WriteLine(tweet);

            var searchParameter = Search.CreateTweetSearchParameter("");
            //searchParameter.SetGeoCode(174.77624,-41.28646, 20, DistanceMeasure.Miles);
            searchParameter.SetGeoCode(174.76333, -36.84846, 2000, DistanceMeasure.Kilometers);
            searchParameter.Lang = Language.English;
//            searchParameter.SearchType = SearchResultType.Popular;
            searchParameter.MaximumNumberOfResults = 10000;
//            searchParameter.Until = new DateTime(2013, 12, 1);
//            searchParameter.SinceId = 399616835892781056;
//            searchParameter.MaxId = 405001488843284480;
            var tweets = Search.SearchTweets(searchParameter);

//            var follower = user.Followers.First().ScreenName;
            //var tweet = user.LatestHomeTimeline.First();

            Tweet realtweet = new Tweet();
            //{
            //    Content = tweet.Text,
            //    UserName = tweet.Creator.ScreenName,
            //    Lat = tweet.Coordinates.Latitude,
            //    Long = tweet.Coordinates.Longitude
            //};

            return realtweet;

            //var credentials = TwitterCredentials.CreateCredentials("Access_Token", "Access_Token_Secret", "Consumer_Key", "Consumer_Secret");
            //   credentials.
            //TwitterCredentials.ExecuteOperationWithCredentials(credentials, () =>
            //{
            //Tweet.PublishTweet("myTweet");
            //    var user = User.GetUserFromScreenName("iaink23");
            //});
            //TwitterCredentials.
        }
    }
}
