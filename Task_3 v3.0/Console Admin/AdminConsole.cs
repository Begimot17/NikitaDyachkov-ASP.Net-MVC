using Shop.DAL.Contracts;
using Shop.DAL.Models;
using System;
using System.Linq;

namespace Console_Admin
{
    class AdminConsole
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Admin");
            while (true)
            {
                XmlManager xmlman = new XmlManager();

                ProductManager prodman = new ProductManager();
                Product prod = new Product();
                Console.WriteLine("1=CatalogShow\n2=ShowCategory\n3=AddProduct\n4=Delete\n5=Search\n6=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: prodman.Show(); break;
                    case 2: prodman.ShowCategory(); break;
                    case 3: prodman.Add(); break;
                    case 4: prodman.Remove(); break;
                    case 5: prodman.Search(); break;
                    case 6: return;
                    default: Console.WriteLine("WRONG ENTRY!!!"); break;

                }
            }
        }
    }
}
