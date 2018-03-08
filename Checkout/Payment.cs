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

            var list = BasketManager.activelist[userID].ShowContent;
            return list;

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
