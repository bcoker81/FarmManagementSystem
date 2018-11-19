namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class archiveAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "Archived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "Archived");
        }
    }
}
