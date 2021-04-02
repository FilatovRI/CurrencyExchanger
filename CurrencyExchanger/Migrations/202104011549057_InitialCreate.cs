namespace CurrencyExchanger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrencyHistories",
                c => new
                    {
                        HistoryId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                        Text = c.String(),
                        Currency_CurrencyId = c.Int(),
                    })
                .PrimaryKey(t => t.HistoryId)
                .ForeignKey("dbo.CurrencyInfoes", t => t.Currency_CurrencyId)
                .Index(t => t.Currency_CurrencyId);
            
            CreateTable(
                "dbo.CurrencyInfoes",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EngName = c.String(),
                        Nominal = c.Int(nullable: false),
                        ParentCode = c.String(),
                        ISONumCode = c.Int(nullable: false),
                        ISOCharCode = c.String(),
                        ID = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrencyHistories", "Currency_CurrencyId", "dbo.CurrencyInfoes");
            DropIndex("dbo.CurrencyHistories", new[] { "Currency_CurrencyId" });
            DropTable("dbo.CurrencyInfoes");
            DropTable("dbo.CurrencyHistories");
        }
    }
}
