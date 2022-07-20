namespace Clearence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Course", c => c.String());
            AddColumn("dbo.AspNetUsers", "Department", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Department");
            DropColumn("dbo.AspNetUsers", "Course");
        }
    }
}
