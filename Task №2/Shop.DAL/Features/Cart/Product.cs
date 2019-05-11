using System;
namespace Shop.DAL.Features.Cart
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public Product() { }
        public Product(string name , string description , string type,int price)
        {
            Name = name;
            Description = description;
            Type = type;
            Price = price;
        }
    }
}
