using EasyNetQ;
using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Retail
{
    public class RetailPublisher_Login
    {
        public static void ReplyToLoginAttempt(Cookie cookie) {
            Publish(cookie);
        }

        public static void Publish(Cookie cookie)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Publishing cookie with account string: " + cookie.CurrentCookieString); //Showing password for debugging.
                bus.Publish(cookie);
            }
        }
    }
}
