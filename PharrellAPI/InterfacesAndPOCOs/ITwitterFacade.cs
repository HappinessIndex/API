using System.Collections.Generic;

namespace InterfacesAndPOCOs
{
    public interface ITwitterFacade
    {
        IEnumerable<Tweet> GetTweets();
    }
}