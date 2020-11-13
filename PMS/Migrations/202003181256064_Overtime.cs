namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Overtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaves", "LeaveName", c => c.String());
            AddColumn("dbo.Leaves", "LeaveReason", c => c.String());
            AddColumn("dbo.Leaves", "LeaveStatus", c => c.String());
            AddColumn("dbo.Overtimes", "OvertimeDate", c => c.String());
            AddColumn("dbo.Overtimes", "OvertimeStatus", c => c.String());
            DropColumn("dbo.Leaves", "Name");
            DropColumn("dbo.Leaves", "Reason");
            DropColumn("dbo.Leaves", "Status");
            DropColumn("dbo.Overtimes", "Date");
            DropColumn("dbo.Overtimes", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Overtimes", "Status", c => c.String());
            AddColumn("dbo.Overtimes", "Date", c => c.String());
            AddColumn("dbo.Leaves", "Status", c => c.String());
            AddColumn("dbo.Leaves", "Reason", c => c.String());
            AddColumn("dbo.Leaves", "Name", c => c.String());
            DropColumn("dbo.Overtimes", "OvertimeStatus");
            DropColumn("dbo.Overtimes", "OvertimeDate");
            DropColumn("dbo.Leaves", "LeaveStatus");
            DropColumn("dbo.Leaves", "LeaveReason");
            DropColumn("dbo.Leaves", "LeaveName");
        }
    }
}
