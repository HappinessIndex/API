using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace PharrellAPI.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AU12 { get; set; }
        public DbGeography Polygon { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}