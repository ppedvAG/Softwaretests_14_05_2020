using ppedv.Stocky.Logic;
using ppedv.Stocky.Model;
using System;
using System.Linq;

namespace ppedv.Stocky.UI.CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Stocky v0.1 ***");

            var core = new Core();

            foreach (var b in core.Repository.GetAll<Bulk>())
            {
                Console.WriteLine($"{b.Type} {b.Storage.Sum(x => x.Menge)}kg");
            }


            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
