using System;
using System.Collections;
using System.Collections.Generic;
using ShoppingSystem_Entities;


namespace ShoppingSystem_Entities
{
    public class Baskets
    {
        private List<Product> _basketContents;
        private int _objInBasket;

        public Baskets()
        {
            _basketContents = new List<Product>();
            _objInBasket = _basketContents.Count;
        }

        public void AdditemToBasket(Product p)
        {
            _basketContents.Add(p);
        }

        public void RemoveItemFromBasket(Product p)
        {
            _basketContents.Remove(p);
        }

        public List<Product> ShowContent
        {
            get { return _basketContents; }
        }

        public void DisplayBasket() {
            Console.WriteLine("Basket content");
            foreach (var product in _basketContents)
            {
                if (product == null)
                {
                    Console.WriteLine("Basket product is null");
                }
                string productString = product.Name;//String.Format("ID: {0}, Name: {1}, Quantity: {2}, Price for each: {3}", product.ID, product.Name, product.Quantity, product.Price);
                Console.WriteLine(productString);
            }
        }

    }
}
