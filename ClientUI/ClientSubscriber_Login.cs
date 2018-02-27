using EasyNetQ;
using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientUI
{
    class ClientSubscriber_Login
    {
        public static bool AwaitLoginReply() {
            return Subscribe();
        }

        public static bool Subscribe()
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<Cookie>("test", HandleProduct);

                Console.WriteLine("Listening for login verification cookie. Hit >ENTER< to quit.");
                Console.ReadLine();
            }
            return Cookie.ClientCheckIsValidUserString("NotLoggedIn");
        }

        static void HandleProduct(Cookie cookie)
        {
            ClientSession.ClientCookie = cookie;
            if (Cookie.ClientCheckIsValidUserString(cookie.CurrentCookieString))
            {
                Console.WriteLine("Successfully logged in.");
            }
            else
            {
                Console.WriteLine("Failed to log in.");
            }
            Console.WriteLine("Please press >ENTER< to continue...");
        }
    }
}
