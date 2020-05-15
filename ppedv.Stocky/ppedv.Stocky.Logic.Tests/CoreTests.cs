
using Moq;
using NUnit.Framework;
using ppedv.Stocky.Model;
using ppedv.Stocky.Model.Contracts;
using System;

namespace ppedv.Stocky.Logic.Tests
{
    public class CoreTests
    {
        [Test]
        public void Core_GetStockWithMostBulk_MitTestRepo()
        {
            var core = new Core(new TestRepo());

            var result = core.GetStockWithMostBulk();

            Assert.AreEqual("Lager 2", result.Name);
        }

        [Test]
        public void Core_GetStockWithMostBulk_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Stock>()).Returns(() =>
            {
                var s1 = new Stock() { Name = "Lager 1" };
                var s2 = new Stock() { Name = "Lager 2" };
                var b = new Bulk() { Type = "Nasser Dreck" };

                var s1A1 = new Section() { Nummer = "s1A1" };
                s1A1.Storages.Add(new Storage() { Bulk = b, Menge = 12 });
                s1.Sections.Add(s1A1);

                var s1A2 = new Section() { Nummer = "s1A2" };
                s1A2.Storages.Add(new Storage() { Bulk = b, Menge = 4 });
                s1.Sections.Add(s1A2);

                var s2A1 = new Section() { Nummer = "s2A1" };
                s2A1.Storages.Add(new Storage() { Bulk = b, Menge = 9 });
                s2.Sections.Add(s2A1);

                var s2A2 = new Section() { Nummer = "s2A2" };
                s2A2.Storages.Add(new Storage() { Bulk = b, Menge = 9 });
                s2.Sections.Add(s2A2);
                return new[] { s1, s2 };
            });

            var core = new Core(mock.Object);

            var result = core.GetStockWithMostBulk();

            Assert.AreEqual("Lager 2", result.Name);

        }

    }
}