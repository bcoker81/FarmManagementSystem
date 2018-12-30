namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBreedBackToText : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Breed", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "Breed", c => c.Int(nullable: false));
        }
    }
}
