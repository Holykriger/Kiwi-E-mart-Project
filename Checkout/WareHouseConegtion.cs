using System;
using System.Collections.Generic;
using System.Text;
using ShoppingSystem_Entities;
using Product = ShoppingSystem_Entities.Product;
namespace Checkout
{
    public class WareHouseConegtion
    {
        // the incoming prouct is use i wareHouse Controller as a description of what the customor wants,
        public List<List<Product>> GetProdukts(List<Product> Wantedproducts)
        {
            List<List<Product>> ProduktsList = new List<List<Product>>();
            List<Product> ProduktList = new List<Product>();
            //WareHouseController WHC = GetWarhousecontroller();
            foreach (var wantedproduct in Wantedproducts)
            {
              //  WHC.
            }
            //Get WareHouse Controller and use FindProduct(product)
            return ProduktsList;
        }
    }
}
