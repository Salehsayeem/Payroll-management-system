namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesignationVal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Designations", "DesignationName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Designations", "DesignationName", c => c.String());
        }
    }
}
