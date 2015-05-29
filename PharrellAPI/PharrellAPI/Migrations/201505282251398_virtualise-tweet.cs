namespace PharrellAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualisetweet : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Results", name: "TweetId_Id", newName: "Tweet_Id");
            RenameIndex(table: "dbo.Results", name: "IX_TweetId_Id", newName: "IX_Tweet_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Results", name: "IX_Tweet_Id", newName: "IX_TweetId_Id");
            RenameColumn(table: "dbo.Results", name: "Tweet_Id", newName: "TweetId_Id");
        }
    }
}
