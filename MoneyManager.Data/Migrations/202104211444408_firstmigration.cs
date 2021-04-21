namespace MoneyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RetirementAcct", "UserID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RetirementAcct", "UserID");
        }
    }
}
