using System;

namespace Retail
{
    class Program
    {
        static void Main(string[] args)
        {
            RetailRequestResponse_Login.AwaitLoginAttempts();
            Basket.BasketManager.CreateObjectPool(10);
            Basket.BasketManager.FillTestBasket("Dennis123");
            Basket.BasketManager.FillTestBasket("Martin123");
            Basket.BasketManager.FillTestBasket("Simon123");
            Basket.BasketManager.FillTestBasket("Alex123");


        }
    }
}
