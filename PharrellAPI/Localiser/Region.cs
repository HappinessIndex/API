using System.Collections.Generic;
using System.Data.Entity.Spatial;
using Interfaces;

namespace Spatial
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AU12 { get; set; }
        public DbGeography Polygon { get; set; }
        public virtual ICollection<ISocialDatum> SocialData { get; set; }
    }
}