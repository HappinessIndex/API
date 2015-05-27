namespace PharrellAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_TweetID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tweets", "TweetID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tweets", "TweetID");
        }
    }
}
