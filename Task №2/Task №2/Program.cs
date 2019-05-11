using System;
using System.Collections.Generic;

namespace Task__2
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart.catalog=new List <Product>{
                new Product("Iphone SE 32gb", "Black", "Smartphone", 7999),
                new Product("Ipad PRO", "Silver", "Tablet", 50499),
                new Product("AirPods", "Black", "Headphones", 9749),
                new Product("Iphone XS MAX 512gb", "White", "Smartphone", 46999),
                new Product("Sennheiser MOMENTUM M2", "White", "Headphones", 6999),
                new Product("SAMSUNG Galaxy Tab", "Black", "Tablet", 5999)
            };
            Product[] prod = new Product[100];
            Cart cart = new Cart();
            while (true)
            {
                Console.WriteLine("1=CatalogShow\n2=CartShow\n3=AddToCatalog\n4=AddToCart\n5=Remove\n6=Sort\n7=Search\n8=Update\n9=Exit");
                if(int.TryParse(Console.ReadLine(), out int i))
                switch (i)
                {
                    case 1: cart.CatalogShow(); break;
                    case 2: cart.CartShow(); break;
                    case 3: cart.AddToCatalog(prod); break;
                    case 4: cart.Add(); break;
                    case 5: cart.Remove(); break;
                    case 6: cart.SetSort(); break;
                    case 7: cart.Search(); break;
                    case 8: cart.Update(); break;
                    case 9: return;
                    default: Console.WriteLine("Wrong input"); break;
                }
            }
        }
    }
}
