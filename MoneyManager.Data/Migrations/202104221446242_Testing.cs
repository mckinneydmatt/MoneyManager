namespace MoneyManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "LiquidNetWorth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "LiquidNetWorth", c => c.Double(nullable: false));
        }
    }
}
