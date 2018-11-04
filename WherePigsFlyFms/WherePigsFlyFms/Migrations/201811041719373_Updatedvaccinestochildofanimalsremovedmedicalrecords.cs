namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedvaccinestochildofanimalsremovedmedicalrecords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VaccinationModels",
                c => new
                    {
                        VaccineId = c.Int(nullable: false, identity: true),
                        VaccinneDescription = c.String(),
                        VaccineDate = c.DateTime(nullable: false),
                        FK_Animal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VaccineId)
                .ForeignKey("dbo.Animals", t => t.FK_Animal_Id, cascadeDelete: true)
                .Index(t => t.FK_Animal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VaccinationModels", "FK_Animal_Id", "dbo.Animals");
            DropIndex("dbo.VaccinationModels", new[] { "FK_Animal_Id" });
            DropTable("dbo.VaccinationModels");
        }
    }
}
