namespace Clearence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newleo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "IsFinance", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "DeanOfStudent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "IsRegistrar", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "IsRegistrar");
            DropColumn("dbo.Students", "DeanOfStudent");
            DropColumn("dbo.Students", "IsFinance");
        }
    }
}
