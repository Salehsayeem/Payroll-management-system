namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Designation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Designations", "DesignationName", c => c.String());
            DropColumn("dbo.Designations", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Designations", "Name", c => c.String());
            DropColumn("dbo.Designations", "DesignationName");
        }
    }
}
