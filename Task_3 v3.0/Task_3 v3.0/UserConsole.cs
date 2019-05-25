using Shop.DAL.Contracts;
using System;

namespace Task_3_v3._0
{
    class UserConsole
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ProductManager prodman = new ProductManager();
                UserManager userman = new UserManager();
                Console.WriteLine("1=Registration\n2=Log in\n3=Products\n4=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: userman.Registration(); break;
                    case 2: userman.Login(); break;
                    case 3: prodman.CatalogShow(); break;
                    case 4: return;
                    default: Console.WriteLine("Неверный ввод!!!"); break;
                }
            }
        }
    }
}
