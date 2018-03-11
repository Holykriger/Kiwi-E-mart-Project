using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EasyNetQ;
using ShoppingSystem_Entities;
using ShoppingSystem_Entities.HTTPRequests;

namespace Retail
{
    public class RetailToWarehouseCtrl_TopicBased
    {
        public enum WhichWarehouses { All, City, Country }

        public int id { get; set; }
        IBus bus;
        bool gotReply;
        HTTPRequest_WarehouseToRetail toReturn;

        public RetailToWarehouseCtrl_TopicBased() {
            bus = RabbitHutch.CreateBus("host=localhost;timeout=4");
        }

        public HTTPRequest_WarehouseToRetail PublishToWarehouse(Location location, HTTPRequest_RetailToWarehouse request, WhichWarehouses whichWarehouses = WhichWarehouses.All)
        {
            string topic = GetTopic(location, whichWarehouses);
            using (bus)
            {
                Console.WriteLine("Publishing with topic: " + topic);
                //var message = new TextMessage { Text = topic };
                bus.Publish<HTTPRequest_RetailToWarehouse>(request, topic);
 
                Console.WriteLine("Subscribing to topic: " + topic);
                bus.Subscribe<HTTPRequest_WarehouseToRetail>("subscriber" + id, HandleResponse, x => x.WithTopic(topic));
                Console.WriteLine("Listening for messages.");

            lock (this)
            {
                gotReply = Monitor.Wait(this, 3000);
            }

                if (gotReply)
                    return toReturn;
                else
                    return new HTTPRequest_WarehouseToRetail();
        }
        }

        void HandleResponse(HTTPRequest_WarehouseToRetail response)
        {
            toReturn = response;
            lock (this)
            {
                Monitor.Pulse(this);
            }
        }

        static string GetTopic(Location location, WhichWarehouses whichWarehouses)
        {
            string topic = "Warehouse.";
            switch (whichWarehouses)
            {
                case WhichWarehouses.All:
                    topic = topic + "*";
                    break;
                case WhichWarehouses.City:
                    topic = topic + location.Country+ "." + location.Municipality;
                    break;
                case WhichWarehouses.Country:
                    topic = topic + location.Country + ".*";
                    break;
                default:
                    break;

            }
            return topic;
        }
    }
}
