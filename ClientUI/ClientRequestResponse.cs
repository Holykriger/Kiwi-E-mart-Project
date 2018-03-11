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
    public class ClientRequestResponse
    {
        #region Request sending and reply handling
        static MonitorObject MonitorObject;
        public static void SendRequest(HTTPRequest_ClientToGateway request)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost;timeout=5"))
            {
                try
                {
                    MonitorObject = new MonitorObject();
                    MonitorObject.StartMonitoring();
                    request.Cookie = ClientSession.ClientCookie;
                    #region HTTP command setup
                    
                    #endregion
                    var task = bus.RequestAsync<HTTPRequest_ClientToGateway, HTTPRequest_RetailerToClientGateway>(request);

                    // Each response is handled by a separate task.
                    // the requester can have multiple outstanding requests.
                    task.ContinueWith(response => HandleResponse(response)).Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("Request to server failed.");
                }
            }
        }

        static void HandleResponse(Task<HTTPRequest_RetailerToClientGateway> response)
        {
            MonitorObject.StopMonitoring();
            Console.WriteLine("Command type received: " + response.Result.RetailCmd);
            Console.WriteLine("Request time: " + MonitorObject.TimeSpan);
            Console.WriteLine("Cookie received: "+ response.Result.Cookie.CurrentCookieString);
            switch (response.Result.RetailCmd)
            {
                case HTTPRequest_ClientToGateway.RetailCommand.Login:
                    ClientRequestResponse_Login.HandleLoginResponse(response);
                    break;
                case HTTPRequest_ClientToGateway.RetailCommand.AddProduct:
                    ClientRequestResponse_Basket.AddProductHandleResponse(response);
                    break;
                case HTTPRequest_ClientToGateway.RetailCommand.RemoveProduct:
                    break;
                case HTTPRequest_ClientToGateway.RetailCommand.ViewAllProducts:
                    ClientRequestResponse_ViewProducts.ViewProductsHandleResponse(response);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }

}
