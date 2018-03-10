using System;
using System.Collections.Generic;
using System.Text;
using ShoppingSystem_Entities;

namespace ClientUI
{
    public class Client_Logout
    {
        public static void LogOut() {
            if (ClientSession.ClientCookie != null)
            {
                ClientSession.ClientCookie.CurrentCookieString = "NotLoggedIn";
                ClientSession.Basket = null;
                Console.WriteLine("Succesfully logged out.");
            }
        }
    }
}
