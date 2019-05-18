using Shop.DAL.Contracts;
using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_v3._0
{
    class UserConsole
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Product p = new Product();
                Console.WriteLine("1=Registration\n2=Log in\n3=Products\n4=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: UserManager.Registration(); break;
                    case 2: UserManager.Login(); break;
                    case 3: CartManager.CatalogShow(); break;
                    case 4: return;
                    default: Console.WriteLine("Неверный ввод!!!"); break;
                }
            }
        }
    }
}
