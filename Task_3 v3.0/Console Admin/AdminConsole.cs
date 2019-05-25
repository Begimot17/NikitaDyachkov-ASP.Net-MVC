using Shop.DAL.Contracts;
using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Admin
{
    class AdminConsole
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Admin");
            while (true)
            {
                Product prod = new Product();
                Console.WriteLine("1=CatalogShow\n2=AddProduct\n3=Delete\n4=Sort\n5=Search\n6=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: ProductManager.CatalogShow(); break;
                    case 2: ProductManager.Add(); break;
                    case 3: ProductManager.Delete(); break;
                    case 4: ProductManager.Sort(XmlManager.DisProd().ToList()); break;
                    case 5: ProductManager.Search(); break;
                    case 6: return;
                    default: Console.WriteLine("WRONG ENTRY!!!"); break;

                }
            }
        }
    }
}
