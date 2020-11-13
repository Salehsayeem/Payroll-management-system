namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initital2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advances", "Date", c => c.String());
            AddColumn("dbo.Advances", "Reason", c => c.String());
            AddColumn("dbo.Advances", "Amount", c => c.String());
            AddColumn("dbo.Advances", "Status", c => c.String());
            AddColumn("dbo.Advances", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Allowances", "Type", c => c.String());
            AddColumn("dbo.Allowances", "Amount", c => c.String());
            AddColumn("dbo.Allowances", "Status", c => c.String());
            AddColumn("dbo.Deductions", "Date", c => c.String());
            AddColumn("dbo.Deductions", "Reason", c => c.String());
            AddColumn("dbo.Deductions", "Amount", c => c.String());
            AddColumn("dbo.Deductions", "Status", c => c.String());
            AddColumn("dbo.Deductions", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "AllowanceId", c => c.Int(nullable: false));
            AddColumn("dbo.Leaves", "Name", c => c.String());
            AddColumn("dbo.Leaves", "StartDate", c => c.String());
            AddColumn("dbo.Leaves", "EndDate", c => c.String());
            AddColumn("dbo.Leaves", "Reason", c => c.String());
            AddColumn("dbo.Leaves", "Status", c => c.String());
            AddColumn("dbo.Leaves", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Overtimes", "Date", c => c.String());
            AddColumn("dbo.Overtimes", "StartTime", c => c.String());
            AddColumn("dbo.Overtimes", "EndTime", c => c.String());
            AddColumn("dbo.Overtimes", "RatePerHour", c => c.String());
            AddColumn("dbo.Overtimes", "Status", c => c.String());
            AddColumn("dbo.Overtimes", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Advances", "EmployeeId");
            CreateIndex("dbo.Employees", "AllowanceId");
            CreateIndex("dbo.Deductions", "EmployeeId");
            CreateIndex("dbo.Leaves", "EmployeeId");
            CreateIndex("dbo.Overtimes", "EmployeeId");
            AddForeignKey("dbo.Employees", "AllowanceId", "dbo.Allowances", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Advances", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Deductions", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Leaves", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Overtimes", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            DropTable("dbo.Salaries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Overtimes", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Leaves", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Deductions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Advances", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "AllowanceId", "dbo.Allowances");
            DropIndex("dbo.Overtimes", new[] { "EmployeeId" });
            DropIndex("dbo.Leaves", new[] { "EmployeeId" });
            DropIndex("dbo.Deductions", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "AllowanceId" });
            DropIndex("dbo.Advances", new[] { "EmployeeId" });
            DropColumn("dbo.Overtimes", "EmployeeId");
            DropColumn("dbo.Overtimes", "Status");
            DropColumn("dbo.Overtimes", "RatePerHour");
            DropColumn("dbo.Overtimes", "EndTime");
            DropColumn("dbo.Overtimes", "StartTime");
            DropColumn("dbo.Overtimes", "Date");
            DropColumn("dbo.Leaves", "EmployeeId");
            DropColumn("dbo.Leaves", "Status");
            DropColumn("dbo.Leaves", "Reason");
            DropColumn("dbo.Leaves", "EndDate");
            DropColumn("dbo.Leaves", "StartDate");
            DropColumn("dbo.Leaves", "Name");
            DropColumn("dbo.Employees", "AllowanceId");
            DropColumn("dbo.Deductions", "EmployeeId");
            DropColumn("dbo.Deductions", "Status");
            DropColumn("dbo.Deductions", "Amount");
            DropColumn("dbo.Deductions", "Reason");
            DropColumn("dbo.Deductions", "Date");
            DropColumn("dbo.Allowances", "Status");
            DropColumn("dbo.Allowances", "Amount");
            DropColumn("dbo.Allowances", "Type");
            DropColumn("dbo.Advances", "EmployeeId");
            DropColumn("dbo.Advances", "Status");
            DropColumn("dbo.Advances", "Amount");
            DropColumn("dbo.Advances", "Reason");
            DropColumn("dbo.Advances", "Date");
        }
    }
}
