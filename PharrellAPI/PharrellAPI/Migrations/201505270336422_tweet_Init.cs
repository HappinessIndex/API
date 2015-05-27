namespace PharrellAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tweet_Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        UserName = c.String(),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tweets");
        }
    }
}
