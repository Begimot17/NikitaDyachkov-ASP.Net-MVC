using Shop.DAL.Contracts;
using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_3_v3._0
{
    public class UserManager
    {
        public User GetNewUser()
        {
            User newUser = new User();
            Console.Write("Enter Name->");
            newUser.Name = Console.ReadLine();
            Console.Write("Enter Email->");
            newUser.Email = Console.ReadLine();
            Console.Write("Enter (min 6 chars) Password->");
            newUser.Pass = Console.ReadLine();
            return newUser;
        }

        public   void Registration()
        {
            XmlManager xmlman = new XmlManager();
            string fileUser = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3 v3.0\Shop.DAL\Repositories\Users.xml";
            while (true)
            {
                User newUser = GetNewUser();
                bool name = Regex.IsMatch(newUser.Name, @"^[\p{L} \.\-]+$");
                bool email = Regex.IsMatch(newUser.Email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                bool pass = Regex.IsMatch(newUser.Pass, @"[0-9a-zA-Z!@#$%^&*]{6,}");
                if (name && email && pass)
                {
                    foreach (User x in xmlman.DisUser(fileUser))
                    {
                        if (x.Name == newUser.Name)
                        {
                            Console.WriteLine("A user with the same name already exists");
                            return;
                        }
                        if (x.Email == newUser.Email)
                        {
                            Console.WriteLine("A user with the same email already exists");
                            return;
                        }
                    }
                    List<User> newUserList = xmlman.DisUser(fileUser).ToList();
                    newUserList.Add(newUser);
                    xmlman.SerUser(newUserList.ToArray(), fileUser);
                    UserConsole(newUser.Name);

                }
                else
                {
                    Console.WriteLine("WRONG ENTRY");
                }
            }
        }
        public  void Login()
        {
            XmlManager xmlman = new XmlManager();
            string fileUser = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3 v3.0\Shop.DAL\Repositories\Users.xml";
            User temp = new User();
            Console.Write("Enter Email->");
            string Email = Console.ReadLine();
            Console.Write("Enter (min 6 chars) Password->");
            string Pass = Console.ReadLine();
            List<User> newUserList = xmlman.DisUser(fileUser).ToList();

            foreach (User x in newUserList)
                {
                    if (x.Pass == Pass && x.Email == Email)
                    {
                        UserConsole(x.Name);
                    }
                }
                Console.WriteLine("Invalid email or password");
            
        }
        public  void UserConsole(string Name)
        {
            XmlManager xmlman = new XmlManager();

            Cart cart = new Cart();
            Console.WriteLine($"Hello {Name}");
            while (true)
            {
                ProductManager prodman = new ProductManager();
                CartManager cartman = new CartManager();

                Console.WriteLine("1=CatalogShow\n2=ShowCategory\n3=CartShow\n4=AddProduct\n5=Delete\n6=Search\n7=Sort\n8=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: prodman.Show(); break;
                    case 2: prodman.ShowCategory(); break;
                    case 3: cartman.Show(Name); break;
                    case 4: cartman.Add(Name); break;
                    case 5: cartman.Remove(Name); break;
                    case 6: prodman.Search(); break;
                    case 7: cartman.Sort(Name);break;
                    case 8: return;
                    default: Console.WriteLine("WRONG ENTRY!!!"); break;
                }
            }
        }
    }
}
