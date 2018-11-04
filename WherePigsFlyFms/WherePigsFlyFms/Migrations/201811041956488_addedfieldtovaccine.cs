namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfieldtovaccine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaccinations", "VaccineName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vaccinations", "VaccineName");
        }
    }
}
