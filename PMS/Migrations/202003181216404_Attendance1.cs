namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attendance1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "AttendanceDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attendances", "AttendanceStatus", c => c.String());
            AddColumn("dbo.Attendances", "AttendanceRemarks", c => c.String());
            DropColumn("dbo.Attendances", "Date");
            DropColumn("dbo.Attendances", "Status");
            DropColumn("dbo.Attendances", "Remarks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Remarks", c => c.String());
            AddColumn("dbo.Attendances", "Status", c => c.String());
            AddColumn("dbo.Attendances", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Attendances", "AttendanceRemarks");
            DropColumn("dbo.Attendances", "AttendanceStatus");
            DropColumn("dbo.Attendances", "AttendanceDate");
        }
    }
}
