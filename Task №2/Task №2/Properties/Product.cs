using System;
namespace Task__2
{
    class Product
    {
        public string Name;
        public string Description;
        public string Type;
        public int Price;
        public Product() { }
        public Product(string Name , string Description , string Type,int Price)
        {
            this.Name = Name;
            this.Description = Description;
            this.Type = Type;
            this.Price = Price;
        }
        static public void Show(Product x)
        {
            Console.WriteLine($"{x.Name,-25}  {x.Description,-6}  {x.Type,-10}  {x.Price,-5}");
        }
    }
}
