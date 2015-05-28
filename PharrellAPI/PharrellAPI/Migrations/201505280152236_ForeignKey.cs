namespace PharrellAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "TweetId_Id", c => c.Int());
            CreateIndex("dbo.Results", "TweetId_Id");
            AddForeignKey("dbo.Results", "TweetId_Id", "dbo.Tweets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "TweetId_Id", "dbo.Tweets");
            DropIndex("dbo.Results", new[] { "TweetId_Id" });
            DropColumn("dbo.Results", "TweetId_Id");
        }
    }
}
