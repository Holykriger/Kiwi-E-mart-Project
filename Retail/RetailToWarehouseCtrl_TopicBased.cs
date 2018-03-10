using System;
using System.Collections.Generic;
using System.Text;
using EasyNetQ;

namespace Retail
{
    public class RetailToWarehouseCtrl_TopicBased
    {
        public enum WhichWarehouses { All, City, Country }
        
        public void PublishToWarehouse(Location location, WhichWarehouses whichWarehouses = WhichWarehouses.All) {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.Writeline("Publishing with topic: "+topic);
                    //var message = new TextMessage { Text = topic };
                    //bus.Publish<TextMessage>(message, topic);
            }
        }

        public void SubscribeToWarehouse(Location location, WhichWarehouses whichWarehouses = WhichWarehouses.All) {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                //bus.Subscribe<TextMessage>("subscriber" + id, HandleTextMessage, x => x.WithTopic(topic));
                Console.WriteLine("Listening for messages.");
                Console.ReadLine();
            }
        }

        static void HandleResponse(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: " + textMessage.Text);
            Console.ResetColor();
        }

        static string GetTopic(Location location, WhichWarehouses whichWarehouses) {
            string topic = "Warehouse.";
            switch (whichWarehouses)
            {
                case WhichWarehouses.All:
                    topic = topic + "*";
                    break;
                case WhichWarehouses.City:
                    break;
                case WhichWarehouses.Country:
                    break;
                default:
                    break;

            }
            return topic;
        }
    }
}
