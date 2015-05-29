namespace PharrellAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shiftforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SentimentStuffs", "Region_Id", "dbo.Regions");
            DropIndex("dbo.SentimentStuffs", new[] { "Region_Id" });
            AddColumn("dbo.Results", "Region_Id", c => c.Int());
            CreateIndex("dbo.Results", "Region_Id");
            AddForeignKey("dbo.Results", "Region_Id", "dbo.Regions", "Id");
            DropTable("dbo.SentimentStuffs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SentimentStuffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        confidence = c.String(),
                        sentiment = c.String(),
                        Region_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Results", "Region_Id", "dbo.Regions");
            DropIndex("dbo.Results", new[] { "Region_Id" });
            DropColumn("dbo.Results", "Region_Id");
            CreateIndex("dbo.SentimentStuffs", "Region_Id");
            AddForeignKey("dbo.SentimentStuffs", "Region_Id", "dbo.Regions", "Id");
        }
    }
}
