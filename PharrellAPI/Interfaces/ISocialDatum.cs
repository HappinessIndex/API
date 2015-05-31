using System.Data.Entity.Spatial;

namespace Interfaces
{ 
    public interface ISocialDatum
    {
        int Id { get; set; }
        DbGeography Point { get; set; }
    }
}