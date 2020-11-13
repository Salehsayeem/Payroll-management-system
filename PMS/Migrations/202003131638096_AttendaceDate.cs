namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendaceDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "Date", c => c.String());
        }
    }
}
