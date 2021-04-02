namespace CurrencyExchanger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNominalToHist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrencyHistories", "Nominal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CurrencyHistories", "Nominal");
        }
    }
}
