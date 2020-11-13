namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deduction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deductions", "DeductionDate", c => c.String());
            AddColumn("dbo.Deductions", "DeductionReason", c => c.String());
            AddColumn("dbo.Deductions", "DeductionAmount", c => c.String());
            AddColumn("dbo.Deductions", "DeductionStatus", c => c.String());
            DropColumn("dbo.Deductions", "Date");
            DropColumn("dbo.Deductions", "Reason");
            DropColumn("dbo.Deductions", "Amount");
            DropColumn("dbo.Deductions", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deductions", "Status", c => c.String());
            AddColumn("dbo.Deductions", "Amount", c => c.String());
            AddColumn("dbo.Deductions", "Reason", c => c.String());
            AddColumn("dbo.Deductions", "Date", c => c.String());
            DropColumn("dbo.Deductions", "DeductionStatus");
            DropColumn("dbo.Deductions", "DeductionAmount");
            DropColumn("dbo.Deductions", "DeductionReason");
            DropColumn("dbo.Deductions", "DeductionDate");
        }
    }
}
