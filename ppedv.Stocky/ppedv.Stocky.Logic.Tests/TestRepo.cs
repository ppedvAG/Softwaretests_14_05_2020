using ppedv.Stocky.Model;
using ppedv.Stocky.Model.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Stocky.Logic.Tests
{
    public class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            if (typeof(T) == typeof(Stock))
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
                return new[] { s1, s2 }.Cast<T>();
            }
            throw new System.NotImplementedException();
        }

        public T GetbyId<T>(int id) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public void SaveAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new System.NotImplementedException();
        }
    }
}