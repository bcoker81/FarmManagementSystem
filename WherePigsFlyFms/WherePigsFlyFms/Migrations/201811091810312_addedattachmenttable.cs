namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedattachmenttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false, identity: true),
                        AttachmentType = c.String(),
                        FileName = c.String(),
                        BaseData = c.String(),
                        FK_Animal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttachmentId)
                .ForeignKey("dbo.Animals", t => t.FK_Animal_Id, cascadeDelete: true)
                .Index(t => t.FK_Animal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "FK_Animal_Id", "dbo.Animals");
            DropIndex("dbo.Attachments", new[] { "FK_Animal_Id" });
            DropTable("dbo.Attachments");
        }
    }
}
