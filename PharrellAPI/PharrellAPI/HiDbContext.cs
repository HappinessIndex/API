using InterfacesAndPOCOs;
using PharrellAPI.Models;
using RegionLoader;

namespace PharrellAPI
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HiDbContext : DbContext
    {
        // Your context has been configured to use a 'HiDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PharrellAPI.HiDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HiDbContext' 
        // connection string in the application configuration file.
        public HiDbContext()
            : base("name=HiDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Tweet> Tweets { get; set; }
        public virtual DbSet<SentimentStuff> SentimentStuffs { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}