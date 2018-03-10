using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSystem_Entities
{
    public class ClientSession
    {
        public static Cookie ClientCookie { get; set; }
        public static Baskets Basket { get; set; }
        public static List<Product> CurrentProductListDisplayed { get; set; }
    }
}
