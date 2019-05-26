using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL.Contracts
{
    public class ProductManager:Product
    {
        string fileProduct = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3 v3.0\Shop.DAL\Repositories\Products.xml";
        public void Sort()
        {
            XmlManager xmlman = new XmlManager();
            List<Product> prod = xmlman.DisProd(fileProduct).ToList();
            switch (SortBy)
            {
                case SortBy.Name:
                    prod = prod.OrderBy(x => x.Name).ToList();
                    break;
                case SortBy.Description:
                    prod = prod.OrderBy(x => x.Description).ToList();
                    break;
                case SortBy.Type:
                    prod = prod.OrderBy(x => x.Type).ToList();
                    break;
                case SortBy.Price:
                    prod = prod.OrderBy(x => x.Price).ToList();
                    break;
            }
            ShowProd(prod);


        }
        public void SetSort(SortBy sortType)
        {
            SortBy = sortType;
            Sort();
        }
        
        public void Add(Product[] catalog)
        {
            XmlManager xmlman = new XmlManager();
            List<Product> prod = xmlman.DisProd(fileProduct).ToList();
            foreach (Product item in catalog)
            {
                if (item != null)
                    prod.Add(item);
            }
        }
        public void Add()
        {
            XmlManager xmlman = new XmlManager();

            Product product = new Product();
            Console.Write("Enter Name->");
            product.Name = Console.ReadLine();
            Console.Write("Enter Description->");
            product.Description = Console.ReadLine();
            Console.Write("Enter Type->");
            product.Type = Console.ReadLine();
            Console.Write("Enter Price->");
            product.Price = Convert.ToInt32(Console.ReadLine());
            if (xmlman.AddProduct(product, fileProduct))
                Console.WriteLine("Product Added");
        }
        public  void SortProd()
        {
            Product product = new Product();
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
            SetSort(sort);

        }
        public  void AddToCatalog(List<Product> products, Product[] prod)
        {
            for (int i = 0; i < prod.Length; i++)
            {
                Product product = new Product();
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
                        Add(prod);
                        break;
                    }
                }
            }
        }
        public  void CatalogShow()
        {
            XmlManager xmlman = new XmlManager();

            Product prod = new Product();
            int i = 1;
            List<Product> ProdList = xmlman.DisProd(fileProduct).ToList();
            foreach (Product x in ProdList)
            {
                Console.WriteLine("{0,-3}{1,-25}{2,-17}{3,-13}{4}", i++, x.Name, x.Description, x.Type, x.Price);
            }
        }
        public  void ShowProd(List<Product> _products)
        {
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");

            foreach (Product x in _products)
            {
                Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
            }
        }
        public  string SearchProd(List<Product> prod, string prodToSearch, int quest)
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
        public  bool Search()
        {
            XmlManager xmlman = new XmlManager();

            List<Product> ProdList = xmlman.DisProd(fileProduct).ToList();
            Console.WriteLine("Search by 1=Name 2=Description");
            bool isNum = int.TryParse(Console.ReadLine(), out int quest);

            if (quest == 1)
            {
                Console.Write("Enter Name: ");
                Console.WriteLine(SearchProd(ProdList, Console.ReadLine(), quest));
            }
            else if (quest == 2)
            {
                Console.Write("Enter Description: ");
                Console.WriteLine(SearchProd(ProdList, Console.ReadLine(), quest));
            }
            return true;
        }
        public  void Delete()
        {
            XmlManager xmlman = new XmlManager();

            Console.WriteLine("Enter name delete");
            string nameDelete = Console.ReadLine();
            if (xmlman.Remove(nameDelete, fileProduct))
                Console.WriteLine("Product Removed");

        }
    }
}
