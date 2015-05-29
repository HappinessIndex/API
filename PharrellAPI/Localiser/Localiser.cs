using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using Microsoft.SqlServer.Types;
using PharrellAPI;
using PharrellAPI.Models;

namespace SpatialHelpers
{
    public class Localiser
    {
        private HiDbContext _db = new HiDbContext();

        public bool PointInPolygon(Region region, double latitude, double longitude)
        {
            var poly = new SqlGeography();
            switch (region.Polygon.ProviderValue.ToString()[0])
            {
                case 'P':
                    poly = SqlGeography.STPolyFromText(new SqlChars(region.Polygon.WellKnownValue.WellKnownText), 4326);
                    break;

                case 'M':
                    poly = SqlGeography.STMPolyFromText(new SqlChars(region.Polygon.WellKnownValue.WellKnownText), 4326);
                    break;
            }
            var point = SqlGeography.STPointFromText(
                new SqlChars(string.Format("POINT({0} {1})", longitude, latitude)), 4326);
            return (bool)poly.STContains(point);
        }

        public void UpdateRegions()
        {
            foreach (var result in _db.Results.ToList())
            {
                Debug.WriteLine(string.Format("Checking {0}...", result.Id));
                foreach (var region in _db.Regions.ToList())
                {
                    Debug.WriteLine("Checking region {0}...", region.Id);
                    if (PointInPolygon(region, result.Tweet.Lat, result.Tweet.Long))
                    {
                        region.Results.Add(result);
                        _db.SaveChanges();
                        Debug.WriteLine(string.Format("Added {0} to {1}...", result.Tweet.Id, region.Name));
                        break;
                    }
                }
            }
        }
    }
}