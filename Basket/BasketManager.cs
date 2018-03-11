using System;
using System.Collections.Generic;
using System.Text;
using ShoppingSystem_Entities;

namespace Basket
{
    public class BasketManager
    {
        private static BasketManager Instance;
        private BasketManager() {

        }
        public static BasketManager Singleton() {
            if (Instance == null)
            {
                Instance = new BasketManager();
            }
            return Instance;
        }

        //reference to the objectpool blueprint
        static BasketObjectPool<Baskets> objPool;

        //static dict of active baskets
        public static Dictionary<string, Baskets> activelist = new Dictionary<string, Baskets>();



        //adds object to user's basket
        public Baskets AddObjectToUserBasket(string userID, Product product)
        {
            Baskets basket = activelist[userID];
            basket.AdditemToBasket(product);
            return basket;
        }

        //get user's basket
        public Baskets GetUserBasket(string userID)
        {
            Baskets basket = activelist[userID];
            return basket;
        }

        //removes product from user's basket
        public void RemoveObjectFromUserBasket(string userID, Product product)
        {
            activelist[userID].RemoveItemFromBasket(product);
        }


        //releases object in the pool, and removes from dict
        public void ReleaseObject(Baskets obj, string userID)
        {
            if (activelist.ContainsKey(userID))
            {
                //releases the basket back to the objpool
                objPool.Release(activelist[userID]);
                //removes it from the dictionary
                activelist.Remove(userID);
            }
            else
            {
                //throws exception if userID not in dict
                throw new ArgumentException("activeList dictionary doesn't contain the userID key", "UserID");
            }
            
        }

        //gets object from pool, and adds it to the dict
        public static void GetObjectPool(string userID)
        {
            
            //gets object from the pool
            Baskets obj = objPool.Get();
            if (obj == null)
            {
                Console.WriteLine("Basket obj is null");
            }
            else
            {
                Console.WriteLine("Adding to object pool");
            }
            //moves it to the dictionary
            activelist.Add(userID, obj);

        }

        //creates the objectpool where size is the amount of empty baskets
       public static void CreateObjectPool(int size)
        {
            Console.WriteLine("Creating basket object pool.");
             objPool = new BasketObjectPool<Baskets>(size);
        }

        public static void FillTestBasket(string userID)
        {
            Console.WriteLine("Filling test basket for " + userID);
            GetObjectPool(userID);
            activelist[userID].AdditemToBasket(new Product{ ID = 1, Name = "Banana", Quantity = 5, Description = "Its a Banana"});
            activelist[userID].AdditemToBasket(new Product { ID = 2, Name = "Seng", Quantity = 4, Description = "Its a Bed God Damnit" });
        }

    }
}
