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
            var allTweets = tweetFacade.GetTweets();
            db.Tweets.AddRange(allTweets);
            db.SaveChanges();
        }

        
        
    }
    
}