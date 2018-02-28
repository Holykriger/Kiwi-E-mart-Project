using System;
using System.Collections.Generic;
using System.Text;
using ShoppingSystem_Entities;

namespace Basket
{
    public class BasketManager
    {
        //reference to the objectpool blueprint
        BasketObjectPool<Baskets> objPool;

        //static dict of active baskets
        public static Dictionary<string, Baskets> activelist = new Dictionary<string, Baskets>();



        //adds object to user's basket
        public void AddObjectToUserBasket(string userID, Product product)
        {
            activelist[userID].AdditemToBasket(product);
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
        public void GetObjectPool(string userID)
        {
            
            //gets object from the pool
            Baskets obj = objPool.Get();

            //moves it to the dictionary
            activelist.Add(userID, obj);

        }

        //creates the objectpool where size is the amount of empty baskets
       public void CreateObjectPool(int size)
        {
             objPool = new BasketObjectPool<Baskets>(size);
        }

    }
}
