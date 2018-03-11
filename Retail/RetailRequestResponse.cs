using EasyNetQ;
using ShoppingSystem_Entities;
using ShoppingSystem_Entities.HTTPRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Basket;

namespace Retail
{
    public class RetailRequestResponse
    {

        public static void ReceiveAndHandleRequests()
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost;timeout=4"))
            {
                bus.RespondAsync<HTTPRequest_ClientToGateway, HTTPRequest_RetailerToClientGateway>(request => Task.Factory.StartNew(() => 
                {
                    Console.WriteLine("Command type received: "+request.RetailCmd);
                    HTTPRequest_RetailerToClientGateway response = new HTTPRequest_RetailerToClientGateway();
                    response.Cookie = request.Cookie;
                    switch (request.RetailCmd)
                    {
                        case HTTPRequest_ClientToGateway.RetailCommand.Login:
                            response = RetailRequestResponse_Login.AttemptLogin(request);
                            break;
                        case HTTPRequest_ClientToGateway.RetailCommand.AddProduct:
                            response = RetailRequestResponse_Basket.AttemptToAddProduct(request);
                            break;
                        case HTTPRequest_ClientToGateway.RetailCommand.RemoveProduct:
                            break;
                        case HTTPRequest_ClientToGateway.RetailCommand.ViewAllProducts:
                            response = RetailRequestResponse_ViewProducts.AttemptToViewProducts(request);
                            break;
                        default:
                            break;
                    }
                    response.RetailCmd = request.RetailCmd;
                    return response;
                }
                ));
                Console.WriteLine("Listening for client commands. Hit >ENTER< to quit.");
                Console.ReadLine();
            }
        }
    }
}
