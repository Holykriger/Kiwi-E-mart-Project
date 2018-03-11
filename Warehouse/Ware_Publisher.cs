using EasyNetQ;
using ShoppingSystem_Entities;
using ShoppingSystem_Entities.HTTPRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{

    class Ware_Publisher
    {
        string topic;
        int id;
        public void Publish(int id, string topic, HTTPRequest_WarehouseToRetail reply)
        {
            this.id = id;
            this.topic = topic;
            Console.WriteLine("Topic channel: "+topic);
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Publishing response to " + reply.WarehouseCmd + " command.");
                bus.Publish<HTTPRequest_WarehouseToRetail>(reply, x => x.WithTopic(topic));
            }
        }

        //public void Publish() {
        //    using (var bus = RabbitHutch.CreateBus("host=localhost"))
        //    {
        //        var input = "";
        //        Console.WriteLine("Enter a message. 'Quit' to quit.");
        //        while ((input = Console.ReadLine()) != "Quit")
        //        {

        //        }
        //    }
        //}
    }
}
