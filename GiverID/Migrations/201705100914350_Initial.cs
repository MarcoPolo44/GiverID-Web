namespace GiverID.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cards", "CardID");
            DropColumn("dbo.Cards", "UniqueSuffix");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cards", "UniqueSuffix", c => c.String(nullable: false));
            AddColumn("dbo.Cards", "CardID", c => c.String());
        }
    }
}
