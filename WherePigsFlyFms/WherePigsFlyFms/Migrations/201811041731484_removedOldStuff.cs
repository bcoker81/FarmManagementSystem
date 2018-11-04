namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedOldStuff : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VaccinationModels", newName: "Vaccinations");
            DropForeignKey("dbo.MedicalRecords", "FK_Animal_Id", "dbo.Animals");
            DropIndex("dbo.MedicalRecords", new[] { "FK_Animal_Id" });
            CreateTable(
                "dbo.Lookup",
                c => new
                    {
                        LookupId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LookupId);
            
            AddColumn("dbo.Vaccinations", "VaccineNotes", c => c.String());
            DropTable("dbo.MedicalRecords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        MedicalRecordId = c.Int(nullable: false, identity: true),
                        DogParvovirus = c.DateTime(),
                        DogDistemper = c.DateTime(),
                        DogHepatitis = c.DateTime(),
                        DogLeptospirosis = c.DateTime(),
                        DogBordetella = c.DateTime(),
                        OtherCare = c.String(),
                        Microchip = c.String(),
                        MicrochipDate = c.DateTime(),
                        RabiesVac = c.DateTime(),
                        Catpanleuk = c.DateTime(),
                        CatRespVirus = c.DateTime(),
                        EctoParasites = c.DateTime(),
                        EctoParasiteNotes = c.String(),
                        BloodParasites = c.DateTime(),
                        BloodParasiteNotes = c.String(),
                        IntestinalParasites = c.String(),
                        IntestinalParasiteNotes = c.String(),
                        FK_Animal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicalRecordId);
            
            DropColumn("dbo.Vaccinations", "VaccineNotes");
            DropTable("dbo.Lookup");
            CreateIndex("dbo.MedicalRecords", "FK_Animal_Id");
            AddForeignKey("dbo.MedicalRecords", "FK_Animal_Id", "dbo.Animals", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Vaccinations", newName: "VaccinationModels");
        }
    }
}
