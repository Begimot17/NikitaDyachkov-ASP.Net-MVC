using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__2
{
    class Cart:IAction
    {
        public int SortBy { get; set; }

        public void Add(ref List<Product> prod)
        {
            string Name;
            Console.Write("Введите названия: ");
            Name = Console.ReadLine();

            string Description;
            Console.Write("Введите описание:");
            Description = Console.ReadLine();

            string Type;
            Console.Write("Введите колличество товара:");
            Type = Console.ReadLine();

            int Price;
            Console.Write("Введите цену продукта:");
            Price = Convert.ToInt32(Console.ReadLine());

            Product product = new Product(Name, Description, Type, Price);
            prod.Add(product);
        }
         public void Remove(ref List<Product> prod)
        {
            Console.WriteLine("Введите имя продукта");
            string prodToDelete=Console.ReadLine();
            foreach(Product x in prod)
            {
                if (x.Name == prodToDelete)
                {
                    prod.Remove(x);
                    break;
                }
            }
        }
         public void Update(ref List<Product> prod)
        {

        }
         public void Contains(List<Product> prod)
        {
            foreach (Product x in prod)
            {
                Console.WriteLine($"Name    Description    Type    Price");
                Console.WriteLine($"{x.Name}    {x.Description}    {x.Type}    {x.Price}");
            }
        }
         public void Search(List<Product> prod)
        {
            Console.WriteLine("Введите имя продукта");
            string prodToSearch = Console.ReadLine();
            foreach (Product x in prod)
            {
                if (x.Name == prodToSearch)
                    Console.WriteLine();
            }
        }
    }
}
