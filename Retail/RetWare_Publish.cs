using EasyNetQ;
using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Retail
{
    class RetWare_Publish
    {
        static int id = 0;

        public static void Publish()
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new Product
                    {
                        ID = id++,
                        Name = "ProductName" + id,
                        Description = "ProductDescription" + id,
                        Quantity = 5
                    });
                }
            }
        }
    }
}
