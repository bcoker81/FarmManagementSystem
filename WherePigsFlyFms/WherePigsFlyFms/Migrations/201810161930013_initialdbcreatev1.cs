namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdbcreatev1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TagNumber = c.String(),
                        Breed = c.Int(nullable: false),
                        BreedText = c.String(),
                        Gender = c.Int(nullable: false),
                        Weight = c.Int(),
                        DateOfBirth = c.DateTime(),
                        DateAcquired = c.DateTime(nullable: false),
                        AnimalType = c.String(),
                        NameOfDoner = c.String(),
                        DonerAddress1 = c.String(),
                        DonerAddress2 = c.String(),
                        DonerCity = c.String(),
                        DonerState = c.String(),
                        DonerZip = c.String(),
                        DonerPhone = c.String(),
                        DonerEmail = c.String(),
                        DateRemovedOrSold = c.DateTime(),
                        DateEuthenizedOrDied = c.DateTime(),
                        PhotoUri = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.MedicalRecordId)
                .ForeignKey("dbo.Animals", t => t.FK_Animal_Id, cascadeDelete: true)
                .Index(t => t.FK_Animal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecords", "FK_Animal_Id", "dbo.Animals");
            DropIndex("dbo.MedicalRecords", new[] { "FK_Animal_Id" });
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.Animals");
        }
    }
}
