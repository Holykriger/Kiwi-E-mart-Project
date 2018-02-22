using EasyNetQ;
using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Retail
{
    public class RetailSubscriber_Login
    {
        public static bool AwaitLoginAttempts()
        {
            return Subscribe();
        }

        public static bool Subscribe()
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<User>("test", HandleProduct);

                Console.WriteLine("Listening for login attempts. Hit >ENTER< to quit.");
                Console.ReadLine();
            }
            return Cookie.ClientCheckIsValidUserString("NotLoggedIn");
        }

        static void HandleProduct(User user)
        {
            Console.WriteLine("Checkin if user is valid, info received - USERNAME: "+ user.userName + " PASSWORD: " +user.password);
            //Todo: remember to verify password and not just username.
            if (!Cookie.ServerCheckIsValidUserString("NotLoggedIn"))
            {
                Console.WriteLine("Valid user, sending verification cookie.");
                Cookie cookie = new Cookie(); 
                cookie.CurrentCookieString = GetUserAccountString(user.userName);
                RetailPublisher_Login.ReplyToLoginAttempt(cookie);
            }
            else
            {
                Console.WriteLine("User could not be verified.");
            }
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Got message: {0}", product.ID);
            //Console.WriteLine(product.Name);
            //Console.WriteLine(product.Description);
            //Console.WriteLine(product.Quantity);
            //Console.WriteLine();
            //Console.ResetColor();
        }

        public static string GetUserAccountString(string userName) {
            string accountString = "NotLoggedIn";
            switch (userName)
            {
                case "Dennis":
                    accountString = "Dennis123";
                    break;
                case "Martin":
                    accountString = "Martin123";
                    break;
                case "Simon":
                    accountString = "Simon123";
                    break;
                case "Alex":
                    accountString = "Alex123";
                    break;
                default:
                    break;
            }
            return accountString;
        }
    }
}
