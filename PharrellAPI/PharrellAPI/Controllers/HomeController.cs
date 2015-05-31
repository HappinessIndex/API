using System.Linq;
using System.Web.Mvc;
using PharrellAPI.DAL;
using SpatialHelpers;

namespace PharrellAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HiDbContext _db = new HiDbContext();
        private readonly Localiser _localiser = new Localiser();

        // Temp
        public void UpdateRegions()
        {
            foreach (var tweet in _db.Tweets)
            {
                if (!tweet.Point.Latitude.HasValue || !tweet.Point.Longitude.HasValue)
                {
                    // Can't use a tweet without a location
                    _db.Tweets.Remove(tweet);
                    _db.SaveChanges();
                    break;
                }

                foreach (var region in _db.Regions.ToList())
                {
                    if (_localiser.PointInPolygon(region, tweet.Point.Latitude.Value, tweet.Point.Longitude.Value))
                    {
                        region.SocialData.Add(tweet);
                        _db.SaveChanges();
                        break;
                    }
                }
            }
        }
    }
}