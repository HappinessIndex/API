using System.Data.Entity.Spatial;
using Interfaces;

namespace SocialData.Plugins.Twitter
{
    public class Tweet : ISocialDatum
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DbGeography Point { get; set; }
        public long TweetId { get; set; }
        public int HappinessIndex { get; set; }
    }
}
