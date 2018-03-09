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
        public List<Product> GetProdukts(Product product)
        {
            List<Product> ProduktList = new List<Product>();
            
            //Get WareHouse Controller and use FindProduct(product)
            return ProduktList;
        }
    }
}
