using ShoppingSystem_Entities;
using System;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Warehouse console initializing...");
            Console.WriteLine("Please enter ID and hit >ENTER<");
            string id = Console.ReadLine();
            int idAsInt = -1;
            int.TryParse(id, out idAsInt);
            Console.WriteLine("Please enter country and hit >ENTER<");
            string country = Console.ReadLine();
            Console.WriteLine("Please enter municipality and hit >ENTER<");
            string municipality = Console.ReadLine();
            Warehouse wareHouse = new Warehouse(idAsInt, country, municipality);
            //Ware_Subscribe.Subscribe();
        }
    }
}
