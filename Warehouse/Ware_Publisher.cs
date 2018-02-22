using EasyNetQ;
using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{

    class Ware_Publisher
    {
        static int id = 0;

        public void Publish() {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new Product
                    {
                        ID = id,
                        Name = "ProductName"+ id,
                        Description = "ProductDescription"+ id,
                        Quantity = 5
                    });
                    id++;
                }
            }
        }
    }
}
