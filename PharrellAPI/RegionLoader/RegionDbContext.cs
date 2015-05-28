namespace RegionLoader
{
    using System.Data.Entity;

    public class RegionDbContext : DbContext
    {
        public RegionDbContext()
            : base("name=RegionDbContext")
        {
        }

        public virtual DbSet<Region> Regions { get; set; }
    }
}