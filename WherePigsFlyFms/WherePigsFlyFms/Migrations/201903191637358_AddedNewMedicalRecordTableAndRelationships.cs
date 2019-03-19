namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewMedicalRecordTableAndRelationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        MedicalRecordId = c.Int(nullable: false, identity: true),
                        IncidentDate = c.DateTime(),
                        IncidentDescription = c.String(maxLength: 30),
                        Resolution = c.String(maxLength: 200),
                        Notes = c.String(maxLength: 200),
                        VetInvolved = c.String(maxLength: 50),
                        VetLocation = c.String(maxLength: 20),
                        IsDeleted = c.Boolean(nullable: false),
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
        }
    }
}
