using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi;
using TweetinviProvider;

namespace PharrellAPI.Models
{
    public class StoreTweets
    {

           public void SaveTweetsToDb()
        {
            var db = new HiDbContext();
            TweetinviFacade tweetFacade = new TweetinviFacade();
               //var tweetsList = db.Tweets.ToList();
               //long maxTweetID = tweetsList.OrderByDescending(x => x.Id).ElementAt(0).TweetID;
            var allTweets = tweetFacade.GetTweets();
            db.Tweets.AddRange(allTweets);
            db.SaveChanges();
        }

        
        
    }
    
}