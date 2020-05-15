using ppedv.Stocky.Model;
using ppedv.Stocky.Model.Contracts;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ppedv.Stocky.Logic.Tests")]

namespace ppedv.Stocky.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Stock GetStockWithMostBulk()
        {
            return Repository.GetAll<Stock>().OrderByDescending(x => x.Sections.SelectMany(y => y.Storages).Sum(y => y.Menge)).FirstOrDefault();
        }

        internal void IfFreitagNachMittagAddEnde(DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Friday && dt.Hour > 16)
            {
                Repository.Add(new Bulk() { Type = "Ende" });
                //Repository.Add(new Stock() { Name = "Ende" });
                Repository.SaveAll();
            }
        }


        public Core(IRepository repos) //DI 
        {
            Repository = repos;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }
    }
}
