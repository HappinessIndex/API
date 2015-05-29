using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace PharrellAPI.Controllers
{
    public class ApiFeatureCollection
    {
        public string type { get; set; }
        public ICollection<ApiFeature> features { get; set; }
    }

    public class ApiFeature
    {
        public string type { get; set; }
        public int id { get; set; }
        public ApiProperties properties { get; set; }
        public ApiGeometry geometry { get; set; }
    }

    public class ApiGeometry
    {
        public string type { get; set; }
        public DbGeography coordinates { get; set; }
    }

    public class ApiProperties
    {
        public int AU12 { get; set; }
        public int happinessIndex { get; set; }
    }
}