namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentVal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.String());
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String());
        }
    }
}
