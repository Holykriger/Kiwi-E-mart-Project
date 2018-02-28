using EasyNetQ;
using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Retail
{
    public class RetailRequestResponse_Login
    {
        public static void AwaitLoginAttempts()
        {
            ReceiveAndHandleLoginAttempts();
        }

        static void ReceiveAndHandleLoginAttempts()
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.RespondAsync<User, Cookie>(request => Task.Factory.StartNew(() => 
                {
                    return AttemptLogin(request);
                }
                ));

                Console.WriteLine("Listening for login attempts. Hit >ENTER< to quit.");
                Console.ReadLine();
            }
        }

        static Cookie AttemptLogin(User user)
        {
            Console.WriteLine("Checkin if user is valid, info received - USERNAME: "+ user.userName + " PASSWORD: " +user.password);
            //Todo: remember to verify password and not just username.

            if (User.VerifyUserCredentials(user))
            {
                Console.WriteLine("Valid user, sending verification cookie.");
                Cookie cookie = new Cookie(); 
                cookie.CurrentCookieString = GetUserAccountString(user.userName);
                return cookie;
            }
            else
            {
                Console.WriteLine("User could not be verified.");
                return null;
            }
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
                    accountString = "NotValidUser";
                    break;
            }
            return accountString;
        }
    }
}
