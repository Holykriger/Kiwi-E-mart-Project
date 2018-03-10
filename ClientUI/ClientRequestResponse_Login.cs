using EasyNetQ;
using EasyNetQ.Topology;
using Monitoring;
using ShoppingSystem_Entities;
using ShoppingSystem_Entities.HTTPRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Basket;

namespace ClientUI
{
    public class ClientRequestResponse_Login
    {
 
        static bool LoggedInSuccesfully;

        public static void HandleLoginResponse(Task<HTTPRequest_RetailerToClientGateway> response)
        {
            if (response.Result != null)
            {
                Cookie cookieReceived = response.Result.Cookie;
                ClientSession.ClientCookie = cookieReceived;
                ClientSession.CurrentProductListDisplayed = response.Result.Products;
                Console.WriteLine("User string: " + cookieReceived.CurrentCookieString);
                if (Cookie.ClientCheckIsValidUserString(cookieReceived.CurrentCookieString))
                {
                    LoggedInSuccesfully = true;
                    Console.WriteLine("Successfully logged in.");
                    Console.WriteLine("");
                    //ClientSession.CurrentProductListDisplayed = response.Result.Products;
                    //ClientSession.Basket = response.Result.Basket;
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

        public static bool IsLoggedIn()
        {
            if (ClientSession.ClientCookie == null)
            {
                return false;
            }
            return Cookie.ClientCheckIsValidUserString(ClientSession.ClientCookie.CurrentCookieString);
        }
    }
}
