using EasyNetQ;
using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    class ClientRequestResponse_Login
    {
        /*
         To measure:
         "Where is the problem?" before you start fixing it.
         Response times from client to server.
         Response times inside server.
         Database response times.
        */

        static bool LoggedInSuccesfully;
        public static void AttemptLogin(string userName, string password) {
            Login(userName, password);
            
        }

        static void Login(string userName, string password)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost;timeout=2"))
            {
                try {
                    Console.WriteLine("Attempting to log in with USERNAME: " + userName + " and PASSWORD: " + password); //Showing password for debugging.
                    var task = bus.RequestAsync<User, Cookie>(new User(userName, password));
                    // Each response is handled by a separate task.
                    // the requester can have multiple outstanding requests.
                    task.ContinueWith(response => HandleResponse(response)).Wait();
                }
                catch (AggregateException ex) {
                    LoggedInSuccesfully = false;
                    Console.WriteLine("Failed to log in.");
                }
            }
        }

        static void HandleResponse(Task<Cookie> response)
        {
            if (response.Result != null)
            {
                Cookie cookieReceived = response.Result;
                ClientSession.ClientCookie = cookieReceived;
                if (Cookie.ClientCheckIsValidUserString(cookieReceived.CurrentCookieString))
                {
                    LoggedInSuccesfully = true;
                    Console.WriteLine("Successfully logged in.");
                }
                else
                {
                    LoggedInSuccesfully = false;
                    Console.WriteLine("Failed to log in.");
                }
            }
            else
            {
                LoggedInSuccesfully = false;
                Console.WriteLine("Failed to log in.");
            }
            Console.WriteLine("Please press >ENTER< to continue...");
        }
    }
}
