using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;

namespace Basket
{
    public class BasketObjectPool<T> where T : new()
    {
        private readonly ConcurrentBag<T> _items = new ConcurrentBag<T>();
        private int _counter = 0;
        private int _MAX;
        

        public BasketObjectPool(int size)
        {
            _MAX = size;
        }



        public void Release(T item)
        {
            if(_counter < _MAX)
            {
                _items.Add(item);
                _counter++;
            }
        }

        public T Get()
        {
            T item;
            if (_items.TryTake(out item))
            {
                _counter--;
                return item;
            }
            else
            {
                T obj = new T();
                _items.Add(obj);
                _counter++;
                return obj;
            }
        }

    }
}
