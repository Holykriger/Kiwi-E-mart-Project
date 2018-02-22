using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSystem_Entities
{
    public class Location
    {
        public string Country { get; set; } //E.g. country name.
        public string Municipality { get; set; } //E.g. country name.
        public int Area { get; set; } //give a number between 0 and 999 typically, distance is then 999 between those 2 numbers.

        public static int Distance(int Area1, int Area2) {
            return Math.Abs(Area1 - Area2);
        }

        /// <summary>
        /// return true if same country.
        /// Uses "StartsWith()" and "ToLower()"
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static bool SameCountry(Location from, Location to) {
            return from.Country.ToLower().StartsWith(to.Country.ToLower());
        }

        /// <summary>
        /// return true if same municipality.
        /// Uses "StartsWith()" and "ToLower()"
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static bool SameMunicipality(Location from, Location to)
        {
            return from.Municipality.ToLower().StartsWith(to.Municipality.ToLower());
        }

        /// <summary>
        /// Calculates cost based on location if in same country.
        /// Otherwise sets default cost of 1000 if in another country.
        /// Should always use from local Warehouse to Client.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static int ShippingCost(Location from, Location to) {
            int cost = 0;
            if (!SameCountry(from, to))
            {
                cost = 1000;
            }
            else
            {
                cost = Distance(from.Area, to.Area);
            }
            return cost;
        }

        /// <summary>
        /// returns -1 if no delivery time could be calculated.
        /// Number returned is days of transportation.
        /// Should always use from local Warehouse to Client.
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static int DeliveryTime(int distance) {
            int deliveryTime = -1;
            deliveryTime = distance / 100;
            if (deliveryTime < 1)
            {
                deliveryTime = 1;
            }
            return deliveryTime;
        }
    }
}
