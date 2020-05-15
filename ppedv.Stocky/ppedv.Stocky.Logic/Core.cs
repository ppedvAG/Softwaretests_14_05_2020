using ppedv.Stocky.Model;
using ppedv.Stocky.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.Stocky.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Stock GetStockWithMostBulk()
        {
            return Repository.GetAll<Stock>().OrderBy(x => x.Sections.SelectMany(y => y.Storages).Sum(y => y.Menge)).FirstOrDefault();
        }


        public Core(IRepository repos) //DI 
        {
            Repository = repos;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }
    }
}
