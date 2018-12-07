namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedwikiurltoanimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "WikiLinkUri", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "WikiLinkUri");
        }
    }
}
