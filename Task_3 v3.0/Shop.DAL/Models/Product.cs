using Shop.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public Product() { }
        static public SortBy SortBy { get; private set; }
        public static void Sort(List<Product> prod)
        {
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
            CartManager.ShowProd(prod);


        }
        public static void SetSort(SortBy sortType, List<Product> prod)
        {
            SortBy = sortType;
            Sort(prod);
        }
        public Product(string name, string description, string type, int price)
        {
            Name = name;
            Description = description;
            Type = type;
            Price = price;
        }
        public static void Add(Product[] catalog, List<Product> products)
        {
            foreach (Product item in catalog)
            {
                if (item != null)
                    products.Add(item);
            }

        }
        public static void Delete()
        {
            Console.WriteLine("Enter name delete");
            string nameDelete = Console.ReadLine();
            if (XmlManager.Remove(nameDelete))
                Console.WriteLine("Product Removed");

        }
        public static void AddProduct()
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
        public static string Search(List<Product> prod, string prodToSearch, int quest)
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
            Console.WriteLine("Search by 1=Name 2=Description");
            bool isNum = int.TryParse(Console.ReadLine(), out int quest);

            if (quest == 1)
            {
                Console.Write("Enter Name: ");
                Console.WriteLine(Product.Search(XmlManager.ProductList(), Console.ReadLine(), quest));
            }
            else if (quest == 2)
            {
                Console.Write("Enter Description: ");
                Console.WriteLine(Product.Search(XmlManager.ProductList(), Console.ReadLine(), quest));
            }
            return true;

        }
    }
}
