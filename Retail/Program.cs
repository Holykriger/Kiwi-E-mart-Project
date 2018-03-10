using Basket;
using System;
using System.Threading;

namespace Retail
{
    class Program
    {
        static void Main(string[] args)
        {
            BasketManager.CreateObjectPool(10);
            BasketManager.FillTestBasket("Dennis123");
            BasketManager.FillTestBasket("Martin123");
            BasketManager.FillTestBasket("Simon123");
            BasketManager.FillTestBasket("Alex123");

            RetailRequestResponse.ReceiveAndHandleRequests();


        }
    }
}
