using System;
namespace Shop.DAL.Features.Cart
{
    class Product
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
        static public void Show(Product x)
        {
            Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
        }
    }
}
