namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OvertimeTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Overtimes", "TotalAmount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Overtimes", "TotalAmount");
        }
    }
}
