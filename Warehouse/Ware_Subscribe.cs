using EasyNetQ;
using ShoppingSystem_Entities;
using ShoppingSystem_Entities.HTTPRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class Ware_Subscribe
    {
        Location location;
        int id;
        List<Product> products;
        string topic;
        Ware_Publisher ware_Publisher;
        public void Subscribe(int id, Location location, List<Product> products)
        {
            this.id = id;
            this.location = location;
            this.products = products;
            topic = GetTopic(location);
            Console.WriteLine("Topic channel: "+ topic);
            ware_Publisher = new Ware_Publisher();
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<HTTPRequest_RetailToWarehouse>("subscriber" + id, HandleResponse, x => x.WithTopic(topic));
                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        void HandleResponse(HTTPRequest_RetailToWarehouse request)
        {
            Console.WriteLine("Received command: "+request.WarehouseCmd);
            HTTPRequest_WarehouseToRetail response = new HTTPRequest_WarehouseToRetail();
            response.WarehouseCmd = request.WarehouseCmd;
            switch (request.WarehouseCmd)
            {
                case HTTPRequest_RetailToWarehouse.WarehouseCommand.ViewProducts:
                    response.Products = products;
                    ware_Publisher.Publish(id, topic, response);
                    break;
                case HTTPRequest_RetailToWarehouse.WarehouseCommand.PurchaseProducts:
                    break;
                default:
                    break;
            }
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Got message: {0}", product.ID);
            //Console.WriteLine(product.Name);
            //Console.WriteLine(product.Description);
            //Console.WriteLine(product.Quantity);
            //Console.WriteLine();
            //Console.ResetColor();
        }

        static string GetTopic(Location location)
        {
            return "Warehouse.*";
            string topic = "Warehouse." + location.Country + "." + location.Municipality;
            return topic;
        }
    }
}
