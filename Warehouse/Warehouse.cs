using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public class Warehouse
    {
        public int id { get; set; }
        public string country { get; set; }
        public string municipality { get; set; }

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
