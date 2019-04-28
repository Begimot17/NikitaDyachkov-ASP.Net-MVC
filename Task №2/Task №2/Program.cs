using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] prod = new Product[100];
            Cart cart = new Cart()
            {
                [0] = new Product("Лимон", "Жёлтый", "Фрукт", 15),
                [1] = new Product("Яблоко", "Красное", "Фрукт", 20),
                [2] = new Product("Лимон", "Жёлтый", "Фрукт", 5),
                [3] = new Product("Киви", "Зелёное", "Фрукт", 10),
                [4] = new Product("Лимон", "Оранжевая", "Фрукт", 432),
                [5] = new Product("Лук", "Зелёный", "Овощь", 23)
            };




            while (true)
            {
                Console.WriteLine("1=Add\n2=Contains\n3=Remove\n4=Update\n5=Sort\n6=Search");
                short i = Convert.ToInt16(Console.ReadLine());
                switch (i)
                {
                    case 1: cart.Add(prod); break;
                    case 2: cart.Contains(); break;
                    case 3: cart.Remove(); break;
                    case 4: cart.Update(); break;
                    case 5: cart.SortToСhange(); break;
                    case 6: cart.Search(); break;
                    case 9: return;
                    default: Console.WriteLine("Неверный ввод"); break;
                }
                Console.WriteLine(cart.SortBy);
            }
        }
    }
}
