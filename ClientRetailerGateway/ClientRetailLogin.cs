using EasyNetQ;
using Monitoring;
using ShoppingSystem_Entities;
using ShoppingSystem_Entities.HTTPRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientRetailerGateway
{
    public class ClientRetailLogin
    {
        #region Login Request-Respond
        public static void ReqResp_ReceiveAndHandleLoginAttempts()
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost;timeout=5"))
            {
                bool reachedLocalWarehouse;
                bus.RespondAsync<HTTPRequest_ClientToGateway, HTTPRequest_RetailerToClientGateway>(request => Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Attempting to log in with USERNAME: " + request.User.userName + " and PASSWORD: " + request.User.password); //Showing password for debugging.
                    return bus.RequestAsync<HTTPRequest_ClientToGateway, HTTPRequest_RetailerToClientGateway>(request).Result;
                }
                ));

                Console.WriteLine("Client-Retailer messaging gateway..");
                Console.WriteLine("Listening for login attempts. Hit >ENTER< to quit.");
                Console.ReadLine();
            }
        }
        #endregion

        #region TopicPublisher
        public static void TopicPublisher() {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                string topic = "";
                Console.WriteLine("Enter a topic: ");

                while ((topic = Console.ReadLine()) != "Quit")
                {
                    var message = new TextMessage { Text = topic };
                    bus.Publish<TextMessage>(message, topic);
                    Console.WriteLine("Enter a new topic: ");
                }
            }
        }
        #endregion
        #region TopicSubscriber
        public static void TopicSubscribe() {
            Console.WriteLine("Enter subscriber id:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter a topic: ");
            var topic = Console.ReadLine();

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<TextMessage>("subscriber" + id, HandleTextMessage, x => x.WithTopic(topic));
                Console.WriteLine("Listening for messages.");
                Console.ReadLine();
            }
        }

        static void HandleTopicSubscribe(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: " + textMessage.Text);
            Console.ResetColor();
        }
        #endregion
    }
}
