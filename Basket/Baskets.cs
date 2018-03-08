using System;
using System.Collections;
using System.Collections.Generic;
using ShoppingSystem_Entities;


namespace Basket
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

    }
}
