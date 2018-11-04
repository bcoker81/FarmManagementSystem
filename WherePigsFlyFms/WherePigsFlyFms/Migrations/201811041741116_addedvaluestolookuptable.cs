namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvaluestolookuptable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaccinations", "VaccineType", c => c.Int(nullable: false));
            DropColumn("dbo.Vaccinations", "VaccinneDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vaccinations", "VaccinneDescription", c => c.String());
            DropColumn("dbo.Vaccinations", "VaccineType");
        }
    }
}
