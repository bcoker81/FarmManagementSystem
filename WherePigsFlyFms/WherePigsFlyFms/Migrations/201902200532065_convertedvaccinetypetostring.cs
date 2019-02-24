namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertedvaccinetypetostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vaccinations", "VaccineType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vaccinations", "VaccineType", c => c.Int(nullable: false));
        }
    }
}
