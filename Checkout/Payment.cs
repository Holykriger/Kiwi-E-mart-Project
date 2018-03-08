using Basket;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using ShoppingSystem_Entities;

namespace Checkout
{
    class Payment
    {
        private Shipment _shipment;
        public List<Product> ListOfProducts(string userID)
        {
            BasketManager.CreateObjectPool(10);

            BasketManager.GetObjectPool(userID);

            //Doesn't show list, list is private, talk with Dennis later
            var list = BasketManager.activelist[userID];
            return null;

        }
        public int TotalCost(List<Product> list)
        {
            int cost = 0;
            foreach (var product in list)
                cost += product.Price;
            return cost;
        }
        public int? CostWithShipment(List<Product> list, Location to)
        {
            _shipment = new Shipment();
            return _shipment.Cost(list, to) + TotalCost(list);
        }
    }
}
