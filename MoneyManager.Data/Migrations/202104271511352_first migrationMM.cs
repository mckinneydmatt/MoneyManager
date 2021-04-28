namespace MoneyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigrationMM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expense", "AccountId", "dbo.RetirementAcct");
            DropIndex("dbo.Expense", new[] { "AccountId" });
            CreateTable(
                "dbo.CheckingAcct",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserAcctNumber = c.Int(nullable: false),
                        CkAcctName = c.String(),
                        CkAcctBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.User", t => t.UserAcctNumber, cascadeDelete: true)
                .Index(t => t.UserAcctNumber);
            
            CreateTable(
                "dbo.CkExpense",
                c => new
                    {
                        CkExpenseId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        CkExpenseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CkExpenseName = c.String(nullable: false),
                        CkDueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CkExpenseId)
                .ForeignKey("dbo.CheckingAcct", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.RetExpense",
                c => new
                    {
                        RetExpenseId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        RetExpenseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RetExpenseName = c.String(nullable: false),
                        RetDueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RetExpenseId)
                .ForeignKey("dbo.RetirementAcct", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.SavExpense",
                c => new
                    {
                        SavExpenseId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        SavExpenseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SavExpenseName = c.String(nullable: false),
                        SavDueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SavExpenseId)
                .ForeignKey("dbo.SavingsAcct", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.SavingsAcct",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserAcctNumber = c.Int(nullable: false),
                        SvAcctName = c.String(),
                        SvAcctBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.User", t => t.UserAcctNumber, cascadeDelete: true)
                .Index(t => t.UserAcctNumber);
            
            AlterColumn("dbo.RetirementAcct", "RtAcctNumber", c => c.String());
            AlterColumn("dbo.RetirementAcct", "RtAcctBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RetirementAcct", "AcctType", c => c.String());
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "PhoneNumber", c => c.String());
            AlterColumn("dbo.User", "Address", c => c.String());
            DropTable("dbo.Expense");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        ExpenseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpenseName = c.String(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
            DropForeignKey("dbo.SavExpense", "AccountId", "dbo.SavingsAcct");
            DropForeignKey("dbo.SavingsAcct", "UserAcctNumber", "dbo.User");
            DropForeignKey("dbo.RetExpense", "AccountId", "dbo.RetirementAcct");
            DropForeignKey("dbo.CkExpense", "AccountId", "dbo.CheckingAcct");
            DropForeignKey("dbo.CheckingAcct", "UserAcctNumber", "dbo.User");
            DropIndex("dbo.SavingsAcct", new[] { "UserAcctNumber" });
            DropIndex("dbo.SavExpense", new[] { "AccountId" });
            DropIndex("dbo.RetExpense", new[] { "AccountId" });
            DropIndex("dbo.CkExpense", new[] { "AccountId" });
            DropIndex("dbo.CheckingAcct", new[] { "UserAcctNumber" });
            AlterColumn("dbo.User", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.User", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RetirementAcct", "AcctType", c => c.String(nullable: false));
            AlterColumn("dbo.RetirementAcct", "RtAcctBalance", c => c.Double(nullable: false));
            AlterColumn("dbo.RetirementAcct", "RtAcctNumber", c => c.String(nullable: false));
            DropTable("dbo.SavingsAcct");
            DropTable("dbo.SavExpense");
            DropTable("dbo.RetExpense");
            DropTable("dbo.CkExpense");
            DropTable("dbo.CheckingAcct");
            CreateIndex("dbo.Expense", "AccountId");
            AddForeignKey("dbo.Expense", "AccountId", "dbo.RetirementAcct", "AccountId", cascadeDelete: true);
        }
    }
}
