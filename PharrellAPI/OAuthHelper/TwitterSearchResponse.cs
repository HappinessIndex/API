using System.Collections.Generic;

namespace OAuthHelper
{
    public class TwitterSearchResponse
    {
        public ICollection<Tweet> statuses { get; set; } 
    }
}