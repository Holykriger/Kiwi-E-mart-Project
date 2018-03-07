using System;
using System.Threading.Tasks;
namespace MultipleWarehouses
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");

            Task.Factory.StartNew(() => new Warehouse.Warehouse(1, "Danmark", "Esbjerg"));
            Task.Factory.StartNew(() => new Warehouse.Warehouse(2, "Tyskland", "München"));
            Task.Factory.StartNew(() => new Warehouse.Warehouse(3, "Norge", "Oslo"));
            //Constructoren får parametre ind.
            //Lokal retailer
            //Hvis ikke lokal retailer, så søger den andre warehouses.
            Console.ReadLine();
        }
    }
}
