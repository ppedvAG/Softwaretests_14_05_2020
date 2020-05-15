using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Xunit;

namespace ppedv.Stocky.Data.EFCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_DB()
        {
            var con = new EfContext();

            con.Database.EnsureDeleted();

            Assert.True(con.Database.EnsureCreated());

            Assert.True((con.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists());
        }
    }
}
