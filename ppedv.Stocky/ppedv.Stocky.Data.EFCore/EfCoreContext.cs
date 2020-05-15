using Microsoft.EntityFrameworkCore;
using ppedv.Stocky.Model;


namespace ppedv.Stocky.Data.EFCore
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Bulk> Bulks { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public EfCoreContext(string conString) : base(new DbContextOptionsBuilder().UseSqlServer(conString).Options)
        { }

        public EfCoreContext() : this("Server=(localdb)\\mssqllocaldb;Database=Stocky_dev_CORE;Trusted_Connection=true")
        { }

    }
}
