using AutoFixture;
using FluentAssertions;
using ppedv.Stocky.Model;
using System;
using Xunit;
using System.Data.Entity;
using System.Linq;

namespace ppedv.Stocky.Data.EF.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_DB()
        {
            var con = new EfContext();

            if (con.Database.Exists())
                con.Database.Delete();

            con.Database.Create();

            Assert.True(con.Database.Exists());
        }

        [Fact]
        public void Can_CRUD_Stock()
        {
            var stock = new Stock() { Name = $"Teststock_{Guid.NewGuid()}" };
            var newName = $"UpdateStock_{Guid.NewGuid()}";

            //CREATE
            using (var con = new EfContext())
            {
                con.Stocks.Add(stock);
                con.SaveChanges();
            }

            //READ
            using (var con = new EfContext())
            {
                var loaded = con.Stocks.Find(stock.Id);
                Assert.NotNull(loaded);
                Assert.Equal(stock.Name, loaded.Name);

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            //check UPDATE
            using (var con = new EfContext())
            {
                var loaded = con.Stocks.Find(stock.Id);
                Assert.Equal(newName, loaded.Name);

                //DELETE
                con.Stocks.Remove(loaded);
                con.SaveChanges();
            }

            //check DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Stocks.Find(stock.Id);
                Assert.Null(loaded);
            }

        }

        [Fact]
        public void can_create_read_testdata_with_autofixture()
        {
            var fix = new Fixture();

            //fix.Customize<Stock>(x => x.Without(y => y.Id));
            //fix.Customize<Storage>(x => x.Without(y => y.Id));
            //fix.Customize<Bulk>(x => x.Without(y => y.Id));
            //fix.Customize<Section>(x => x.Without(y => y.Id));

            fix.Behaviors.Add(new OmitOnRecursionBehavior());

            var stock = fix.Build<Stock>().Create<Stock>();

            using (var con = new EfContext())
            {
                con.Stocks.Add(stock);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Stocks.Find(stock.Id);
                loaded.Should().BeEquivalentTo(stock, x => x.IgnoringCyclicReferences());
            }


            //Stock loadedOhneLL;
            //using (var con = new EfContext())
            //{

            //    loadedOhneLL = con.Stocks.Include(x => x.Sections)
            //                             .Include(x => x.Sections.Select(y => y.Storages))
            //                             .FirstOrDefault(x => x.Id == stock.Id);
            //}
            //loadedOhneLL.Should().BeEquivalentTo(stock, x => x.IgnoringCyclicReferences());
        }
    }
}
