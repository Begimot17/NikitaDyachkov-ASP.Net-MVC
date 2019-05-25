using Shop.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{[Serializable]
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
            ProductManager.ShowProd(prod);


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
        
        
    }
}
