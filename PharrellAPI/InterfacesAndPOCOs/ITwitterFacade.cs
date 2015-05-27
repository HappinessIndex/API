using System.Collections.Generic;
using System.Security.AccessControl;
using System;

namespace InterfacesAndPOCOs
{
    public interface ITwitterFacade
    {


        IEnumerable<Tweet> GetTweets();
    }
}