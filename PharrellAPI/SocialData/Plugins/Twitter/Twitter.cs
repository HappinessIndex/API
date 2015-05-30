using System.Collections.Generic;

namespace SocialData.Plugins.Twitter
{
    public class TweetFetcher
    {
        public IEnumerable<Tweet> FetchTweets()
        {
            TweetinviFacade tweetFacade = new TweetinviFacade();
            return tweetFacade.GetTweets();
        }
    }
}