namespace WherePigsFlyFms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class binaryconvertedtovarchar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attachments", "BaseData", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attachments", "BaseData", c => c.Binary());
        }
    }
}
