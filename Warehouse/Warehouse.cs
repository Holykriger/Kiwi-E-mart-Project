using System;
using System.Collections.Generic;
using System.Text;
using Product = ShoppingSystem_Entities.Product;

namespace Warehouse
{
    public class Warehouse
    {
        public int id { get; set; }
        public string country { get; set; }
        public string municipality { get; set; }
        public List<Product> ProductList = new List<Product>(); // List Af Product som WareHuset har pÅ Stock

        public Warehouse(int id, string country, string municipality)
        {
            this.id = id;
            this.country = country;
            this.municipality = municipality;
            Initialize();
        }

        void Initialize()
        {
            string initialMessage = String.Format("Initialized Warehouse with ID: {0}, COUNTRY: {1}, MUNICIPALITY: {2}", id, country, municipality);
            Console.WriteLine(initialMessage);
            //Ware_Subscribe.Subscribe();
        }
    }
}
