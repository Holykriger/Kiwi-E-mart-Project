using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingSystem_Entities;

namespace Checkout
{
    class Shipment
    {
        public int Cost(List<Product> list, Location to)
        {
            int cost = 0;
            foreach (var product in list.Distinct().ToList())
                cost += Location.ShippingCost(product.Location, to);
            return cost;
        }
        public void Time()
        {

        }
    }
}
