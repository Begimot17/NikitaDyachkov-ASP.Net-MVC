using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Contracts
{
    public class ProductManager
    {
        public static void Add()
        {
            Product product = new Product();
            Console.Write("Enter Name->");
            product.Name = Console.ReadLine();
            Console.Write("Enter Description->");
            product.Description = Console.ReadLine();
            Console.Write("Enter Type->");
            product.Type = Console.ReadLine();
            Console.Write("Enter Price->");
            product.Price = Convert.ToInt32(Console.ReadLine());
            if (XmlManager.AddProduct(product))
                Console.WriteLine("Product Added");
        }
        public static void Sort(List<Product> prod)
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
            Product.SetSort(sort, prod);

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

        public static void CatalogShow()
        {
            Product prod = new Product();
            int i = 1;
            List<Product> ProdList = XmlManager.DisProd().ToList();
            foreach (Product x in ProdList)
            {
                Console.WriteLine("{0,-3}{1,-25}{2,-17}{3,-13}{4}", i++, x.Name, x.Description, x.Type, x.Price);
            }
        }
        public static void ShowProd(List<Product> _products)
        {
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");

            foreach (Product x in _products)
            {
                Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
            }
        }
        public static string SearchProd(List<Product> prod, string prodToSearch, int quest)
        {
            switch (quest)
            {
                case 1:
                    foreach (Product x in prod)
                    {
                        if (x.Name == prodToSearch)
                            return $"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}";
                    };
                    break;
                case 2:
                    foreach (Product x in prod)
                    {
                        if (x.Description == prodToSearch)
                            return $"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}";
                    };
                    break;
                default:
                    return "Sorry";

            }
            return "";
        }
        public static bool Search()
        {
            List<Product> ProdList = XmlManager.DisProd().ToList();
            Console.WriteLine("Search by 1=Name 2=Description");
            bool isNum = int.TryParse(Console.ReadLine(), out int quest);

            if (quest == 1)
            {
                Console.Write("Enter Name: ");
                Console.WriteLine(ProductManager.SearchProd(ProdList, Console.ReadLine(), quest));
            }
            else if (quest == 2)
            {
                Console.Write("Enter Description: ");
                Console.WriteLine(ProductManager.SearchProd(ProdList, Console.ReadLine(), quest));
            }
            return true;
        }
        public static void Delete()
        {
            Console.WriteLine("Enter name delete");
            string nameDelete = Console.ReadLine();
            if (XmlManager.Remove(nameDelete))
                Console.WriteLine("Product Removed");

        }
    }
}
