using Shop.DAL.Contracts;
using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3_v3._0
{
    public class UserManager
    {
       public static User NewUser()
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
       
       public  static void Registration()
        {
            while (true)
            {
                User newUser = NewUser();
                bool name = Regex.IsMatch(newUser.Name, @"^[\p{L} \.\-]+$");
                bool email = Regex.IsMatch(newUser.Email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                bool pass = Regex.IsMatch(newUser.Pass, @"[0-9a-zA-Z!@#$%^&*]{6,}");
                if (name && email && pass)
                {
                    foreach (User x in XmlManager.DisUser())
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
                    List<User> newUserList = XmlManager.DisUser().ToList();
                    newUserList.Add(newUser);
                    XmlManager.SerUser(newUserList.ToArray());
                    UserConsole(newUser.Name);

                }
                else
                {
                    Console.WriteLine("WRONG ENTRY");
                }
            }
        }
        public static void Login()
        {
            User temp = new User();
            Console.Write("Enter Email->");
            string Email = Console.ReadLine();
            Console.Write("Enter (min 6 chars) Password->");
            string Pass = Console.ReadLine();
            List<User> newUserList = XmlManager.DisUser().ToList();

            foreach (User x in newUserList)
                {
                    if (x.Pass == Pass && x.Email == Email)
                    {
                        UserConsole(x.Name);
                    }
                }
                Console.WriteLine("Invalid email or password");
            
        }
        public static void UserConsole(string Name)
        {
            Cart cart = new Cart();
            Console.WriteLine($"Hello {Name}");
            while (true)
            {
                List<Product> Prods = XmlManager.DisProd().ToList();
                Console.WriteLine("1=CatalogShow\n2=CartShow\n3=AddProduct\n4=Delete\n5=Search\n6=Sort\n7=Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: ProductManager.CatalogShow(); break;
                    case 2: CartManager.CartShow(Name); break;
                    case 3: CartManager.Add(Name); break;
                    case 4: CartManager.RemoveProd(Name); break;
                    case 5: ProductManager.Search(); break;
                    case 6: ProductManager.Sort(Prods); break;
                    case 7: return;
                    default: Console.WriteLine("WRONG ENTRY!!!"); break;
                }
            }
        }
    }
}
