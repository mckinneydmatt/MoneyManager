namespace MoneyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.RetirementAcct", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            //CreateTable(
            //    "dbo.RetirementAcct",
            //    c => new
            //        {
            //            AccountId = c.Int(nullable: false, identity: true),
            //            UserAcctNumber = c.Int(nullable: false),
            //            RtAcctNumber = c.String(nullable: false),
            //            RtAcctBalance = c.Double(nullable: false),
            //            AcctType = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.AccountId)
            //    .ForeignKey("dbo.User", t => t.UserAcctNumber, cascadeDelete: true)
            //    .Index(t => t.UserAcctNumber);
            
            //CreateTable(
            //    "dbo.User",
            //    c => new
            //        {
            //            UserAcctNumber = c.Int(nullable: false, identity: true),
            //            UserID = c.Guid(nullable: false),
            //            Name = c.String(nullable: false),
            //            PhoneNumber = c.String(nullable: false),
            //            Address = c.String(nullable: false),
            //            GoalAmount = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.UserAcctNumber);
            
            //CreateTable(
            //    "dbo.IdentityRole",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.IdentityUserRole",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(),
            //            IdentityRole_Id = c.String(maxLength: 128),
            //            ApplicationUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.UserId)
            //    .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
            //    .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
            //    .Index(t => t.IdentityRole_Id)
            //    .Index(t => t.ApplicationUser_Id);
            
            //CreateTable(
            //    "dbo.ApplicationUser",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.IdentityUserClaim",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //            ApplicationUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
            //    .Index(t => t.ApplicationUser_Id);
            
            //CreateTable(
            //    "dbo.IdentityUserLogin",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            LoginProvider = c.String(),
            //            ProviderKey = c.String(),
            //            ApplicationUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.UserId)
            //    .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
            //    .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Expense", "AccountId", "dbo.RetirementAcct");
            DropForeignKey("dbo.RetirementAcct", "UserAcctNumber", "dbo.User");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.RetirementAcct", new[] { "UserAcctNumber" });
            DropIndex("dbo.Expense", new[] { "AccountId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.User");
            DropTable("dbo.RetirementAcct");
            DropTable("dbo.Expense");
        }
    }
}
