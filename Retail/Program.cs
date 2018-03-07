using Basket;
using System;

namespace Retail
{
    class Program
    {
        static void Main(string[] args)
        {
            RetailRequestResponse_Login.AwaitLoginAttempts();
            BasketManager.CreateObjectPool(10);
            BasketManager.FillTestBasket("Dennis123");
            BasketManager.FillTestBasket("Martin123");
            BasketManager.FillTestBasket("Simon123");
            BasketManager.FillTestBasket("Alex123");


        }
    }
}
