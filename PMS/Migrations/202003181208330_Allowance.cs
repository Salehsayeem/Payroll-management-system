namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Allowance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Allowances", "AllowanceType", c => c.String());
            AddColumn("dbo.Allowances", "AllowanceAmount", c => c.String());
            AddColumn("dbo.Allowances", "AllowanceStatus", c => c.String());
            DropColumn("dbo.Allowances", "Type");
            DropColumn("dbo.Allowances", "Amount");
            DropColumn("dbo.Allowances", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Allowances", "Status", c => c.String());
            AddColumn("dbo.Allowances", "Amount", c => c.String());
            AddColumn("dbo.Allowances", "Type", c => c.String());
            DropColumn("dbo.Allowances", "AllowanceStatus");
            DropColumn("dbo.Allowances", "AllowanceAmount");
            DropColumn("dbo.Allowances", "AllowanceType");
        }
    }
}
