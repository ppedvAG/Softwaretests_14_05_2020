using ppedv.Stocky.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Stocky.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Bulk> Bulks { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Stock> Stocks { get; set; }



        public EfContext() : base("Server=(localdb)\\mssqllocaldb;Database=Stocky_dev_EF;Trusted_Connection=true")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();


            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
