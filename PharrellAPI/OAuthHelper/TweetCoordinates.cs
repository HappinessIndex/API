using System.Collections.Generic;

namespace OAuthHelper
{
    public class TweetCoordinates
    {
        public string type { get; set; }
        public ICollection<decimal> coordinates { get; set; }
    }
}