namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllVal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advances", "AdvanceDate", c => c.String(nullable: false));
            AlterColumn("dbo.Advances", "AdvanceAmount", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Basic", c => c.String(nullable: false));
            AlterColumn("dbo.Allowances", "AllowanceType", c => c.String(nullable: false));
            AlterColumn("dbo.Allowances", "AllowanceAmount", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "ShiftName", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "StartTIme", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "EndTime", c => c.String(nullable: false));
            AlterColumn("dbo.Deductions", "DeductionReason", c => c.String(nullable: false));
            AlterColumn("dbo.Deductions", "DeductionAmount", c => c.String(nullable: false));
            AlterColumn("dbo.Leaves", "LeaveReason", c => c.String(nullable: false));
            AlterColumn("dbo.Overtimes", "TotalHour", c => c.String(nullable: false));
            AlterColumn("dbo.Overtimes", "RatePerHour", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Overtimes", "RatePerHour", c => c.String());
            AlterColumn("dbo.Overtimes", "TotalHour", c => c.String());
            AlterColumn("dbo.Leaves", "LeaveReason", c => c.String());
            AlterColumn("dbo.Deductions", "DeductionAmount", c => c.String());
            AlterColumn("dbo.Deductions", "DeductionReason", c => c.String());
            AlterColumn("dbo.Schedules", "EndTime", c => c.String());
            AlterColumn("dbo.Schedules", "StartTIme", c => c.String());
            AlterColumn("dbo.Schedules", "ShiftName", c => c.String());
            AlterColumn("dbo.Allowances", "AllowanceAmount", c => c.String());
            AlterColumn("dbo.Allowances", "AllowanceType", c => c.String());
            AlterColumn("dbo.Employees", "Basic", c => c.String());
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "Phone", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Advances", "AdvanceAmount", c => c.String());
            AlterColumn("dbo.Advances", "AdvanceDate", c => c.String());
        }
    }
}
