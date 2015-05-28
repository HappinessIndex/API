namespace PharrellAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Having_a_go_again1 : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.SentimentStuffs");
        }
    }
}
