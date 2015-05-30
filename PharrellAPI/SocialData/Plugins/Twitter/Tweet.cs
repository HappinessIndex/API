using System.Data.Entity.Spatial;

namespace InterfacesAndPOCOs
{
    public class Tweet
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DbGeography Point { get; set; }
        public long TweetId { get; set; }
        public int HappinessIndex { get; set; }
    }
}
