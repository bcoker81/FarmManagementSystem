namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedattachmentdatatypetobytearray : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attachments", "BaseData", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attachments", "BaseData", c => c.String());
        }
    }
}
