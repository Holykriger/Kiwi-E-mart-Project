using Basket;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using ShoppingSystem_Entities;
using Product = ShoppingSystem_Entities.Product;
namespace Checkout
{
    public class Payment
    {
        Location shippingAddress;
        Product p = new Product();
        public List<Product> ProduktList = new List<Product>();
        public List<Product> listWantedProducts = new List<Product>();
        public List<List<Product>> listOFListOFProducts = new List<List<Product>>();//This is a list of the produckts that wareHouse Sends back

        public Payment()
        {
            ProduktList = new WareHouseConegtion().GetProdukts(p);
        }
        public Receipt MakeReceipt()
        {
            Receipt receipt = new Receipt();
            int price = TotalCost(listWantedProducts);
            int shippingPrice = 0;
            foreach (var ListOFProducts in listOFListOFProducts)
            {
                shippingPrice += 0 + ShipmentCost(ListOFProducts);
            }
            
            int Time = -1;
            receipt.MakeReceipt(price, shippingPrice, Time, listOFListOFProducts);
            return receipt;
        }

        

        // Basket er inkøbs vognen
        public List<Product> ListOfProducts(string userID)
        {
            var list = BasketManager.activelist[userID].ShowContent;
            return list;
        }

        //The Total Cost Of Produkt in Basket
        private int TotalCost(List<Product> list)
        {
            int cost = 0;
            foreach (var product in list)
                cost += product.Price * product.Quantity;
            return cost;
        }

        // this do not work sins it sends the basket ind, and not the return produkts from the warehouses
        public int ShipmentCost(List<Product> list)
        {
            Shipment shipment = new Shipment();
            return shipment.Cost(list, shippingAddress);
        }
    }
}
