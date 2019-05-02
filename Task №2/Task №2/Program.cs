using System;
namespace Task__2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] prod = new Product[100];
            Cart cart = new Cart();
            while (true)
            {
                Console.WriteLine("1=Catalog\n2=AddToCatalog\n3=Contains\n4=Remove\n5=Update\n6=Sort\n7=Search");
                short i = Convert.ToInt16(Console.ReadLine());
                switch (i)
                {
                    case 1: cart.AddFromCatalog(); break;
                    case 2: cart.Add(prod); break;
                    case 3: cart.Contains(); break;
                    case 4: cart.Remove(); break;
                    case 5: cart.Update(); break;
                    case 6: cart.SortToСhange(); break;
                    case 7: cart.Search(); break;
                    case 9: return;
                    default: Console.WriteLine("Wrong input"); break;
                }
                Console.WriteLine(cart.SortBy);
            }
        }
    }
}
