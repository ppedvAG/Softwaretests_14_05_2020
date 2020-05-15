using Microsoft.EntityFrameworkCore;
using ppedv.Stocky.Model;


namespace ppedv.Stocky.Data.EFCore
{
    public class EfContext : DbContext
    {
        public DbSet<Bulk> Bulks { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public EfContext(string conString) : base(new DbContextOptionsBuilder().UseSqlServer(conString).Options)
        { }

        public EfContext() : this("Server=(localdb)\\mssqllocaldb;Database=Stocky_dev_CORE;Trusted_Connection=true")
        { }

    }
}
