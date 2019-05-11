using System;
using System.Collections.Generic;
using Shop.DAL.Features.Cart;

namespace Task__2
{
    public class CartManager
    {
        public static void Sort(List<Product>prod)
        {
            Console.WriteLine("Sort by 1=Name/2=Description/3=Type/4=Price");
            string sortby = "Name";
            bool isNum = int.TryParse(Console.ReadLine(), out int quest);
            switch (quest)
            {
                case 1: sortby = "Name"; break;
                case 2: sortby = "Description"; break;
                case 3: sortby = "Type"; break;
                case 4: sortby = "Price"; break;
                default: return;
            }
            SortBy sort;
            Enum.TryParse(sortby, true, out sort);
            prod[0].SetSort(sort, prod);
        }
        public static void Sort(Cart cart)
        {
            Console.WriteLine("Sort by 1=Name/2=Description/3=Type/4=Price");
            string sortby="Name";
            bool isNum = int.TryParse(Console.ReadLine(), out int quest);
            switch (quest) { 
            case 1: sortby = "Name"; break;
            case 2: sortby = "Description"; break;
            case 3: sortby = "Type"; break;
            case 4: sortby = "Price"; break;
            default: return;
            }
            SortBy sort;
            Enum.TryParse(sortby, true, out sort);
            cart.SetSort(sort);
        }
        public static void AddToCatalog(List<Product> products, Product[] prod)
        {
            for (int i = 0; i < prod.Length; i++)
            {
                Console.Write("Enter Name: ");
                string Name = Console.ReadLine();
                Console.Write("Enter Description:");
                string Description = Console.ReadLine();
                Console.Write("Enter Type:");
                string Type = Console.ReadLine();
                Console.Write("Enter Price:");
                if (int.TryParse(Console.ReadLine(), out int Price))
                {
                    prod[i] = new Product(Name, Description, Type, Price);
                    Console.WriteLine("1=Add more\n2=Сonfirm");
                    int quest = 1;
                    if (int.TryParse(Console.ReadLine(), out quest) && quest == 2)
                    {
                        Product.Add(prod, products);
                        break;
                    }
                }
            }
        }
        public static void Add(List<Product> catalog, Cart cart)
        {
            ShowProd(catalog);
            bool isNum = int.TryParse(Console.ReadLine(), out int quest);
            cart.Add(catalog[quest - 1]);
        }

        public static void ShowCart(Cart cart, int TotalPrice)
        {
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");

            foreach (Product x in cart.Contains())
            {
                Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
            }
            Console.WriteLine($"TotalPrice={TotalPrice}");
        }

        public static void ShowProd(List<Product> _products)
        {
            _products[0].Sort(ref _products);
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");

            foreach (Product x in _products)
            {
                Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
            }
        }
        public static void RemoveProd(Cart cart)
        {
            Console.Write("Enter Name: ");
            cart.Remove(Console.ReadLine());
        }
        public static bool Search(List<Product> _products)
        {
            Console.WriteLine("Search by 1=Name 2=Description");
            bool isNum = int.TryParse(Console.ReadLine(), out int quest);

            if (quest == 1)
            {
                Console.Write("Enter Name: ");
                Console.WriteLine(Product.Search(_products, Console.ReadLine(), quest));
            }
            else if (quest == 2)
            {
                Console.Write("Enter Description: ");
                Console.WriteLine(Product.Search(_products, Console.ReadLine(), quest)); 
            }
            return true;
        }
    }
}
