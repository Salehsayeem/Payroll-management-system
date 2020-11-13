namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Advance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advances", "AdvanceDate", c => c.String());
            AddColumn("dbo.Advances", "AdvanceReason", c => c.String());
            AddColumn("dbo.Advances", "AdvanceAmount", c => c.String());
            AddColumn("dbo.Advances", "AdvanceStatus", c => c.String());
            DropColumn("dbo.Advances", "Date");
            DropColumn("dbo.Advances", "Reason");
            DropColumn("dbo.Advances", "Amount");
            DropColumn("dbo.Advances", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advances", "Status", c => c.String());
            AddColumn("dbo.Advances", "Amount", c => c.String());
            AddColumn("dbo.Advances", "Reason", c => c.String());
            AddColumn("dbo.Advances", "Date", c => c.String());
            DropColumn("dbo.Advances", "AdvanceStatus");
            DropColumn("dbo.Advances", "AdvanceAmount");
            DropColumn("dbo.Advances", "AdvanceReason");
            DropColumn("dbo.Advances", "AdvanceDate");
        }
    }
}
