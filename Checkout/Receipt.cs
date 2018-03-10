using System;
using System.Collections.Generic;
using System.Text;
using Product = ShoppingSystem_Entities.Product;

namespace Checkout
{
    public class Receipt
    {
        public int price;
        public int shippingPrice;
        public int time;
        public List<List<Product>> listOFListOFProducts = new List<List<Product>>();
        public void MakeReceipt(int _Price,int _shippingPrice, int _Time, List<List<Product>> _ListOFListOFProducts)
        {
            price = _Price;
            shippingPrice = _shippingPrice;
            time = _Time;
            listOFListOFProducts = _ListOFListOFProducts;
        }
    }
}
