using System;
using System.Text.RegularExpressions;

namespace Task_3new
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Products p = new Products();
                Console.WriteLine("1=Registration\n2=Log in\n3=Products\n4=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: Registration(); break;
                    case 2: Login(); break;
                    case 3: p.CatalogShow(); break;
                    case 4: return;
                    default: Console.WriteLine("Неверный ввод!!!"); break;
                }
            }

        }
        static void Registration()
        {
            while (true)
            {
                User newUser = new User();
                Console.Write("Enter Name->");
                newUser.Name = Console.ReadLine();
                Console.Write("Enter Email->");
                newUser.Email = Console.ReadLine();
                Console.Write("Enter (min 6 chars) Password->");
                newUser.Pass = Console.ReadLine();
                bool name = Regex.IsMatch(newUser.Name, @"^[\p{L} \.\-]+$");
                bool email = Regex.IsMatch(newUser.Email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                bool pass = Regex.IsMatch(newUser.Pass, @"[0-9a-zA-Z!@#$%^&*]{6,}");
                if (name && email && pass)
                {
                    foreach (User x in newUser.ListUsers())
                    {
                        if (x.Name == newUser.Name)
                        {
                            Console.WriteLine("A user with the same name already exists");
                            break;
                        }
                        if (x.Email == newUser.Email)
                        {
                            Console.WriteLine("A user with the same email already exists");
                            break;
                        }
                    }
                    newUser.NewUser();
                    UserConsole(newUser.Name);

                }
                else
                {
                    Console.WriteLine("WRONG ENTRY");
                }
            }
        }
        static void Login()
        {
            User temp = new User();
            Console.Write("Enter Email->");
            string Email = Console.ReadLine();
            Console.Write("Enter (min 6 chars) Password->");
            string Pass = Console.ReadLine();
            if (Email == "Admin@gmail.com" && Pass == "123456")
            {
                AdminConsole();
            }
            else
            {
                foreach (User x in temp.ListUsers())
                {
                    if (x.Pass == Pass && x.Email == Email)
                    {
                        UserConsole(x.Name);
                    }
                }
                Console.WriteLine("Invalid email or password");
            }
        }
        static void UserConsole(string Name)
        {
            Cart cart = new Cart();
            Console.WriteLine($"Hello {Name}");
            while (true)
            {
                Console.WriteLine("1=CatalogShow\n2=CartShow\n3=AddProduct\n4=Delete\n5=Search\n6=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: cart.CatalogShow(); break;
                    case 2: cart.CartShow(Name); break;
                    case 3: cart.AddProduct(Name); break;
                    case 4: cart.Delete(Name); break;
                    case 5: cart.Search(); break;
                    case 6: return;
                    default: Console.WriteLine("WRONG ENTRY!!!"); break;
                }
            }
        }
        static void AdminConsole()
        {
            Console.WriteLine("Hello Admin");
            while (true)
            {
                Products prod = new Products();
                Console.WriteLine("1=CatalogShow\n2=AddProduct\n3=Delete\n4=Sort\n5=Search\n6=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: prod.CatalogShow(); break;
                    case 2: prod.AddProduct(); break;
                    case 3: prod.Delete(); break;
                    case 4: prod.SortChange(); break;
                    case 5: prod.Search(); break;
                    case 6: return;
                    default: Console.WriteLine("WRONG ENTRY!!!"); break;

                }
            }
        }
    }
}
