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
            Product []prod = new Product[6];
            Cart cart = new Cart();
            List<Product> prodList = new List<Product>();
            prod[0] =new Product("Лимон", "Жёлтый", "Кислый", 15 );
            prod[1] = new Product("Яблоко", "Красное", "Сладкое", 20);
            prod[2] = new Product("Лимон", "Жёлтый", "Сладкий", 30);
            prod[3] = new Product("Киви", "Зелёное", "Кислое", 213);
            prod[4] = new Product("Лимон", "Оранжевая", "Хз", 432);
            prod[5] = new Product("Лук", "Зелёный", "Горький", 523);
            foreach(Product x in prod)
            {
                prodList.Add(x);
            }
            while (true)
            {
                Console.WriteLine("1=Add\n2=Contains\n3=Remove");
                short i = Convert.ToInt16(Console.ReadLine());
                switch (i)
                {
                    case 1: cart.Add(ref prodList); break;
                    case 2: cart.Contains(prodList); break;
                    case 3: cart.Remove(ref prodList); break;
                    case 9: return;
                    default: Console.WriteLine("Неверный ввод"); break;
                }
            }
        }
    }
}
