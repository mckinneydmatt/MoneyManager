namespace MoneyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntTesting3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "UserAcctNumber", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.User", "UserAcctNumber");
            CreateIndex("dbo.CheckingAcct", "UserAcctNumber");
            CreateIndex("dbo.RetirementAcct", "UserAcctNumber");
            CreateIndex("dbo.SavingsAcct", "UserAcctNumber");
            AddForeignKey("dbo.CheckingAcct", "UserAcctNumber", "dbo.User", "UserAcctNumber", cascadeDelete: true);
            AddForeignKey("dbo.RetirementAcct", "UserAcctNumber", "dbo.User", "UserAcctNumber", cascadeDelete: true);
            AddForeignKey("dbo.SavingsAcct", "UserAcctNumber", "dbo.User", "UserAcctNumber", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavingsAcct", "UserAcctNumber", "dbo.User");
            DropForeignKey("dbo.RetirementAcct", "UserAcctNumber", "dbo.User");
            DropForeignKey("dbo.CheckingAcct", "UserAcctNumber", "dbo.User");
            DropIndex("dbo.SavingsAcct", new[] { "UserAcctNumber" });
            DropIndex("dbo.RetirementAcct", new[] { "UserAcctNumber" });
            DropIndex("dbo.CheckingAcct", new[] { "UserAcctNumber" });
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "UserAcctNumber", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.User", "UserId");
        }
    }
}
