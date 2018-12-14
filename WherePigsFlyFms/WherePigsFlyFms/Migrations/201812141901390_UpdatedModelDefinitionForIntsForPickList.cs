namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModelDefinitionForIntsForPickList : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Breed", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "AnimalType", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "DonerState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "DonerState", c => c.String());
            AlterColumn("dbo.Animals", "AnimalType", c => c.String());
            AlterColumn("dbo.Animals", "Breed", c => c.String());
        }
    }
}
