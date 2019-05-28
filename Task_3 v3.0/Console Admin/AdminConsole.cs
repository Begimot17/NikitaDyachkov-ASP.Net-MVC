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
                Console.WriteLine("1=CatalogShow\n2=AddProduct\n3=Delete\n4=Sort\n5=Search\n6=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: prodman.CatalogShow(); break;
                    case 2: prodman.Add(); break;
                    case 3: prodman.Delete(); break;
                    case 4: prodman.Sort(); break;
                    case 5: prodman.Search(); break;
                    case 6: return;
                    default: Console.WriteLine("WRONG ENTRY!!!"); break;

                }
            }
        }
    }
}
