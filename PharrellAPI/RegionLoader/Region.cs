using System.Data.Entity.Spatial;

namespace RegionLoader
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AU12 { get; set; }
        public DbGeography Polygon { get; set; }
    }
}