namespace PharrellAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        confidence = c.Single(nullable: false),
                        sentiment = c.String(),
                        TweetId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tweets", t => t.TweetId_Id)
                .Index(t => t.TweetId_Id);
            
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        UserName = c.String(),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                        TweetID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SentimentStuffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        confidence = c.String(),
                        sentiment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "TweetId_Id", "dbo.Tweets");
            DropIndex("dbo.Results", new[] { "TweetId_Id" });
            DropTable("dbo.SentimentStuffs");
            DropTable("dbo.Tweets");
            DropTable("dbo.Results");
        }
    }
}
