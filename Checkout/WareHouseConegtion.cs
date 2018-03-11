using System;
using System.Collections.Generic;
using System.Text;
using ShoppingSystem_Entities;
using Product = ShoppingSystem_Entities.Product;
using NewTheWareHouseController;

namespace Checkout
{
    public class WareHouseConegtion
    {
        // the incoming prouct is use i wareHouse Controller as a description of what the customor wants,
        public List<List<Product>> GetProdukts(List<Product> Wantedproducts)
        {
            List<List<Product>> ProduktsList = new List<List<Product>>();
            if (Wantedproducts.Count != 0)
            {
                Product newProduct = new Product();
                List<Product> ProduktList = new List<Product>();
                WareHouseController WHC = GetWarhousecontroller();
                //this is for testing
                if (Wantedproducts[0].Name == "This is a Test a Test")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ProduktList = new List<Product>();
                        for (int e = 0; e < 5; e++)
                        {
                            newProduct = new Product();
                            newProduct.ID = e;
                            newProduct.Name = "Name" + i;
                            newProduct.Quantity = (i + 1) * (1 + e);
                            ProduktList.Add(newProduct);
                        }
                        ProduktsList.Add(ProduktList);
                    }
                }
                else
                {
                    foreach (var wantedproduct in Wantedproducts)
                    {
                        //  WHC´'
                        //here we send the wantedproduct, and gets a return from the warehouse, with is a list<Product>, 
                        //these are from the difrent warehouse. there combiende quantaty == wantedproduct, if not there were not enouth on shells
                    }
                    //Get WareHouse Controller and use FindProduct(product)
                }
            }
            return ProduktsList;
        }
        private WareHouseController GetWarhousecontroller()
        {
            WareHouseController WHC = new WareHouseController();
            return WHC;
        }
    }
}
