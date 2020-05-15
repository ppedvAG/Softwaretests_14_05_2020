using AutoFixture;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ppedv.Stocky.Model;
using System;
using Xunit;

namespace ppedv.Stocky.Data.EFCore.Tests
{
    public class EfCoreContextTests
    {
        [Fact]
        public void Can_create_DB()
        {
            var con = new EfCoreContext();

            con.Database.EnsureDeleted();

            Assert.True(con.Database.EnsureCreated());

            Assert.True((con.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists());
        }

        [Fact]
        public void Can_CRUD_Stock()
        {
            var stock = new Stock() { Name = $"Teststock_{Guid.NewGuid()}" };
            var newName = $"UpdateStock_{Guid.NewGuid()}";

            //CREATE
            using (var con = new EfCoreContext())
            {
                con.Stocks.Add(stock);
                con.SaveChanges();
            }

            //READ
            using (var con = new EfCoreContext())
            {
                var loaded = con.Stocks.Find(stock.Id);
                Assert.NotNull(loaded);
                Assert.Equal(stock.Name, loaded.Name);

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            //check UPDATE
            using (var con = new EfCoreContext())
            {
                var loaded = con.Stocks.Find(stock.Id);
                Assert.Equal(newName, loaded.Name);

                //DELETE
                con.Stocks.Remove(loaded);
                con.SaveChanges();
            }

            //check DELETE
            using (var con = new EfCoreContext())
            {
                var loaded = con.Stocks.Find(stock.Id);
                Assert.Null(loaded);
            }

        }

        [Fact]
        public void can_create_read_testdata_with_autofixture()
        {
            var fix = new Fixture();

            fix.Customize<Stock>(x => x.Without(y => y.Id));
            fix.Customize<Storage>(x => x.Without(y => y.Id));
            fix.Customize<Bulk>(x => x.Without(y => y.Id));
            fix.Customize<Section>(x => x.Without(y => y.Id));

            
            fix.Behaviors.Add(new OmitOnRecursionBehavior());

            var stock = fix.Create<Stock>();


            using (var con = new EfCoreContext())
            {
                con.Stocks.Add(stock);
                con.SaveChanges();
            }
        }


    }
}
