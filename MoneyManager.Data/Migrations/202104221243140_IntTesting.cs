namespace MoneyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntTesting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RetirementAcct", "UserAcctNumber", "dbo.User");
            DropIndex("dbo.RetirementAcct", new[] { "UserAcctNumber" });
            DropPrimaryKey("dbo.RetirementAcct");
            DropPrimaryKey("dbo.User");
            AddColumn("dbo.CheckingAcct", "UserAcctNumber", c => c.Int(nullable: false));
            AddColumn("dbo.SavingsAcct", "UserAcctNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.RetirementAcct", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "UserAcctNumber", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RetirementAcct", "UserID");
            AddPrimaryKey("dbo.User", "UserId");
            DropColumn("dbo.CheckingAcct", "UserAccountNumber");
            DropColumn("dbo.SavingsAcct", "UserAccountNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SavingsAcct", "UserAccountNumber", c => c.Int(nullable: false));
            AddColumn("dbo.CheckingAcct", "UserAccountNumber", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.RetirementAcct");
            AlterColumn("dbo.User", "UserAcctNumber", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.RetirementAcct", "AccountId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.SavingsAcct", "UserAcctNumber");
            DropColumn("dbo.CheckingAcct", "UserAcctNumber");
            AddPrimaryKey("dbo.User", "UserAcctNumber");
            AddPrimaryKey("dbo.RetirementAcct", "AccountId");
            CreateIndex("dbo.RetirementAcct", "UserAcctNumber");
            AddForeignKey("dbo.RetirementAcct", "UserAcctNumber", "dbo.User", "UserAcctNumber", cascadeDelete: true);
        }
    }
}
