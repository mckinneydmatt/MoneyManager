namespace MoneyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntTesting1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RetirementAcct");
            AlterColumn("dbo.RetirementAcct", "AccountId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RetirementAcct", "AccountId");
            DropColumn("dbo.RetirementAcct", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RetirementAcct", "UserID", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.RetirementAcct");
            AlterColumn("dbo.RetirementAcct", "AccountId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RetirementAcct", "UserID");
        }
    }
}
