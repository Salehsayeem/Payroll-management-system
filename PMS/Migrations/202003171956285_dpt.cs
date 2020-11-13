namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dpt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DepartmentName", c => c.String());
            AddColumn("dbo.Departments", "DepartmentCode", c => c.String());
            DropColumn("dbo.Departments", "Name");
            DropColumn("dbo.Departments", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "Code", c => c.String());
            AddColumn("dbo.Departments", "Name", c => c.String());
            DropColumn("dbo.Departments", "DepartmentCode");
            DropColumn("dbo.Departments", "DepartmentName");
        }
    }
}
