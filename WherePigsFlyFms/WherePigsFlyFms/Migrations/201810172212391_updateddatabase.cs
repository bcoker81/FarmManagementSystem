namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Breed", c => c.String());
            DropColumn("dbo.Animals", "BreedText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "BreedText", c => c.String());
            AlterColumn("dbo.Animals", "Breed", c => c.Int(nullable: false));
        }
    }
}
