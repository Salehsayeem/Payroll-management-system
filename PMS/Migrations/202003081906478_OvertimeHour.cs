namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OvertimeHour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Overtimes", "TotalHour", c => c.String());
            DropColumn("dbo.Overtimes", "StartTime");
            DropColumn("dbo.Overtimes", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Overtimes", "EndTime", c => c.String());
            AddColumn("dbo.Overtimes", "StartTime", c => c.String());
            DropColumn("dbo.Overtimes", "TotalHour");
        }
    }
}
