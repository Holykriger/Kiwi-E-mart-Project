using EasyNetQ;
using Monitoring;
using ShoppingSystem_Entities;
using ShoppingSystem_Entities.HTTPRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    public class ClientRequestResponse_Basket
    {
        #region Add Product

        public static void AddProductHandleResponse(Task<HTTPRequest_RetailerToClientGateway> response)
        {
            if (response.Result != null)
            {
                Console.WriteLine("Succesfully added product to basket.");
                //handle result
                ClientSession.Basket = response.Result.Basket;
                response.Result.Basket.DisplayBasket();
            }
            else
            {
                Console.WriteLine("ERROR - Basket Error - HTTP Request for confirming product that product was added is null");
            }
            Console.WriteLine("Please press >ENTER< to continue...");
        }
        #endregion
    }

}
