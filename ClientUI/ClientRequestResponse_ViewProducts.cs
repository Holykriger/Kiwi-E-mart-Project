using EasyNetQ;
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
    public class ClientRequestResponse_ViewProducts
    {
        #region View Products

        public static void ViewProductsHandleResponse(Task<HTTPRequest_RetailerToClientGateway> response)//Task<Cookie> response
        {
            if (response.Result != null)
            {
                ClientSession.CurrentProductListDisplayed = response.Result.Products; //Save list in clientsession.
                Console.WriteLine("Product list length: "+response.Result.Products.Count);
                foreach (var product in response.Result.Products)
                {
                    Console.Write("ID: "+product.ID+" ");
                    Console.WriteLine("Product name: "+product.Name);
                }                }
                //handle result
            else
            {
                Console.WriteLine("ERROR - View products error - Response received was null, possibly requires login for accessing it.");
            }
            Console.WriteLine("");
        }
        #endregion
    }

}
