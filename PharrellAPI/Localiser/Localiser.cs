using System.Data.SqlTypes;
using System.Linq;
using Microsoft.SqlServer.Types;
using PharrellAPI;
using PharrellAPI.Models;
using Spatial;

namespace SpatialHelpers
{
    public class Localiser
    {
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

    }
}