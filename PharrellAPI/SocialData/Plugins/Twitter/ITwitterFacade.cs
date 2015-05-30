using System.Collections.Generic;

namespace SocialData.Plugins.Twitter
{
    public interface ITwitterFacade
    {
        IEnumerable<Tweet> GetTweets();
    }
}