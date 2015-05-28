namespace PharrellAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SentimentValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "SentimentValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "SentimentValue");
        }
    }
}
