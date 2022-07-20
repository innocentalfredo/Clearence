namespace Clearence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iscomplete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Iscomplete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Iscomplete");
        }
    }
}
