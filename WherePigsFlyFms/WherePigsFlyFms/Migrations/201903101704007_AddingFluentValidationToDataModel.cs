namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFluentValidationToDataModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Animals", "TagNumber", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "TagNumber", c => c.String());
            AlterColumn("dbo.Animals", "Name", c => c.String(nullable: false));
        }
    }
}
