namespace CurrencyExchanger.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CurrencyContext : DbContext
    {
        public CurrencyContext()
            : base("name=CurrencyContext")
        {
        }

        public DbSet<CurrencyHistory> CurrencyHistories { get; set; }
        public DbSet<CurrencyInfo> CurrencyInfo { get; set; }
        //public DbSet<CurrencyList> CurrencyLists { get; set; }
    }
}