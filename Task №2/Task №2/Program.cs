using System;
namespace Task__2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] prod = new Product[100];
            Cart cart = new Cart();
           /* {
                [0] = new Product("Лимон", "Жёлтый", "Фрукт", 15),
                [1] = new Product("Яблоко", "Красное", "Фрукт", 20),
                [2] = new Product("Лимон", "Жёлтый", "Фрукт", 5),
                [3] = new Product("Киви", "Зелёное", "Фрукт", 10),
                [4] = new Product("Лимон", "Оранжевая", "Фрукт", 432),
                [5] = new Product("Лук", "Зелёный", "Овощь", 23)
            };*/
            while (true)
            {
                Console.WriteLine("1=Catalog\n2=Add\n3=Contains\n4=Remove\n5=Update\n6=Sort\n7=Search");
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
