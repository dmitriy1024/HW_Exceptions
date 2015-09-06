using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Price[] prices = new Price[2];
            string enteredProdName;
            string enteredShopName;
            decimal enteredPrice;

            int count = 0;
            while (count < 2)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Enter the product name ->");
                enteredProdName = Console.ReadLine();

                Console.WriteLine("Enter the shop name ->");
                enteredShopName = Console.ReadLine();

                Console.WriteLine("Enter the price ->");
                if(!Decimal.TryParse(Console.ReadLine(),out enteredPrice))
                {
                    Console.WriteLine("Price must be a number");       
                    continue;
                }

                Price price;
                try
                {
                    price = new Price(enteredProdName, enteredShopName, enteredPrice);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                prices[count] = price;
                count++;
                Console.WriteLine("Price was added");
            }

            Array.Sort(prices, (x,y) => String.Compare(x.ShopName, y.ShopName, true));
            Console.WriteLine("\nALL PRODUCTS");
            foreach (var item in prices)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine("\nEnter the shop name->");
            enteredShopName = Console.ReadLine();

            Price[] prisesInShop = Array.FindAll(prices, x => String.Compare(x.ShopName, enteredShopName, true) == 0);

            if (prisesInShop.Length == 0)
            {
                throw new ShopNotFoundException("Shop not found");
            }                
            else
            {
                Console.WriteLine("\nPRODUCTS IN SHOP {0}", enteredShopName);
                foreach (var item in prisesInShop)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
