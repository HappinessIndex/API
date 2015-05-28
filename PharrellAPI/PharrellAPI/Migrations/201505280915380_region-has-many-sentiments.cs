namespace PharrellAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regionhasmanysentiments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SentimentStuffs", "Region_Id", c => c.Int());
            CreateIndex("dbo.SentimentStuffs", "Region_Id");
            AddForeignKey("dbo.SentimentStuffs", "Region_Id", "dbo.Regions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SentimentStuffs", "Region_Id", "dbo.Regions");
            DropIndex("dbo.SentimentStuffs", new[] { "Region_Id" });
            DropColumn("dbo.SentimentStuffs", "Region_Id");
        }
    }
}
