namespace CurrencyExchanger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrencyHistories", "Value", c => c.Single(nullable: false));
            DropColumn("dbo.CurrencyHistories", "Name");
            DropColumn("dbo.CurrencyHistories", "Text");
            DropColumn("dbo.CurrencyInfoes", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CurrencyInfoes", "Text", c => c.String());
            AddColumn("dbo.CurrencyHistories", "Text", c => c.String());
            AddColumn("dbo.CurrencyHistories", "Name", c => c.String());
            DropColumn("dbo.CurrencyHistories", "Value");
        }
    }
}
