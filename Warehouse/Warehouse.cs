using ShoppingSystem_Entities;
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
        Location location;

        public Warehouse(int id, string country, string municipality)
        {
            location = new Location();
            location.Area = 500;
            location.Country = country;
            location.Municipality = municipality;
            this.id = id;
            this.country = country;
            this.municipality = municipality;
            Initialize();
        }

        void Initialize()
        {
            string initialMessage = String.Format("Initialized Warehouse with ID: {0}, COUNTRY: {1}, MUNICIPALITY: {2}", id, country, municipality);
            Console.WriteLine(initialMessage);
            Ware_Subscribe ware_Subscribe = new Ware_Subscribe();
            ware_Subscribe.Subscribe(id, location, getTestProductList());
        }

        public List<Product> getTestProductList()
        {
            return new List<Product>() {
                    new Product(){ ID = 1, Description = "description1", Name = "Banana", Quantity = 1, Price = 50, Location = location },
                    new Product(){ ID = 2, Description = "description2", Name = "Phone", Quantity = 2, Price = 500, Location = location },
                    new Product(){ ID = 3, Description = "description3", Name = "Bed", Quantity = 3, Price = 5000, Location = location },
                    new Product(){ ID = 4+id, Description = "description4", Name = "Food from "+location.Municipality, Quantity = 1, Price = 50000, Location = location },};
        }
    }
}
