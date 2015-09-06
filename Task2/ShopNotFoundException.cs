using System;

namespace Task2
{
    class ShopNotFoundException : Exception
    {
        public ShopNotFoundException(string message) : base(message){ }
    }
}
