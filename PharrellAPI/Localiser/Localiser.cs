using System.Data.SqlTypes;
using Microsoft.SqlServer.Types;
using RegionLoader;

namespace SpatialHelpers
{
    public class Localiser
    {
        public bool PointInPolygon(Region region, double latitude, double longitude)
        {
            var poly = SqlGeography.STPolyFromText(new SqlChars(region.Polygon.WellKnownValue.WellKnownText), 4326);
            var point = SqlGeography.STPointFromText(
                new SqlChars(string.Format("POINT({0} {1})", latitude, longitude)), 4326);
            return (bool)poly.STContains(point);
        }
    }
}