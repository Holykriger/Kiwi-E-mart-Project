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
        static bool LoggedInSuccesfully;
        public static void AttemptLogin(string userName, string password) {
            Publish(userName, password);
            //Needs to be made async, possibly with tasks. Also need to split Cookie into 2 parts so client and retail don't both listen for cookies. Client when verifying user login and retail when confirming that user is logged in. Can perhaps make a "ConfirmIsLoggedIn" class which holds a cookie.
        }

        static void Publish(string userName, string password)
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
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine(ex.InnerException.Message);
                    //Console.ResetColor();
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
