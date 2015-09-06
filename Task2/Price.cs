using System;

namespace Task2
{
    struct Price
    {
        public readonly string ProductName;
        public readonly string ShopName;
        public readonly decimal ProductPrice;

        public Price(string productName, string shopName, decimal productPrice)
        {
            if(productName == null || shopName == null || productName.Length == 0 || shopName.Length == 0 || productPrice == 0 || productPrice <= 0)
            {
                throw new ArgumentException("Invalid arguments");
            }
            else
            {
                ProductName = productName;
                ShopName = shopName;
                ProductPrice = productPrice;
            }
        }

        public override string ToString()
        {
            return String.Format("ProductName: {0,-10} ShopName: {1,-10} ProductPrice: {2,-5} UAH",ProductName, ShopName, ProductPrice);
        }
    }
}
