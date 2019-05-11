using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL.Features.Cart
{
    
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public Product() { }
        public SortBy SortBy { get; private set; }
        public void Sort(ref List<Product>prod)
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
            
        }
        public void SetSort(SortBy sortType,List<Product>prod)
        {
            SortBy = sortType;
            Sort(ref prod);
        }
        public Product(string name , string description , string type,int price)
        {
            Name = name;
            Description = description;
            Type = type;
            Price = price;
        }
        public static void Add(Product[] catalog, List <Product> products )
        {
            foreach (Product item in catalog)
            {
                if (item!=null)
                products.Add(item);
            }
            
        }
        public static string Search(List<Product>prod, string prodToSearch,int quest)
        {
            switch (quest)
            {
                case 1:
                    foreach (Product x in prod)
                    {
                        if (x.Name == prodToSearch)
                            return $"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}";
                    }  ;
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
    }
}
