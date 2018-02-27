using EasyNetQ;
using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    class ClientRequestResponse_Basket
    {
        public static void AttemptToAddProduct(string product) //should probably be a 'product' object and not a string.
        {
            AddProduct(product);
        }

        static void AddProduct(string product)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost;timeout=2"))
            {
                try
                {
                    //Console.WriteLine("Attempting to log in with USERNAME: " + userName + " and PASSWORD: " + password); //Showing password for debugging.
                    //var task = bus.RequestAsync<User, Cookie>(new User(userName, password));
                    // Each response is handled by a separate task.
                    // the requester can have multiple outstanding requests.
                    //task.ContinueWith(response => HandleResponse(response)).Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("Failed to use Basket.");
                }
            }
        }

        static void HandleResponse(Task<Cookie> response)
        {
            if (response.Result != null)
            {
                //handle result
            }
            else
            {
                Console.WriteLine("ERROR - Basket Error");
            }
            Console.WriteLine("Please press >ENTER< to continue...");
        }
    }
}
