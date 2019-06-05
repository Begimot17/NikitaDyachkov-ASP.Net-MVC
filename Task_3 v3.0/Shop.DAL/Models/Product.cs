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
        public string Manufactur { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public int Price { get; set; }
        public Product() { }
        public Product(string name, string manufactur, string description, string сurrency, int price)
        {
            Name = name;
            Manufactur = manufactur;
            Description = description;
            Currency = сurrency;
            Price = price;
        }
        public virtual void Show()
        {
            Console.WriteLine($"{Name,-15}{Manufactur,-15}{Description,-15}{Price,-15}{Currency,-15}");
        }
        public virtual void Add()
        {
            Console.WriteLine("Name->>>");
            Name = Console.ReadLine();
            Console.WriteLine("Manufactur->>>");
            Manufactur = Console.ReadLine();
            Console.WriteLine("Description->>>");
            Description = Console.ReadLine();
            Console.WriteLine("Сurrency->>>");
            Currency = CurrencySet();
            Console.WriteLine("Price->>>");
            Price = Int32.Parse(Console.ReadLine());
        }
        public string CurrencySet()
        {
            Console.WriteLine("1=UAH\n2=USD\n3=EUR");
            int quest = Convert.ToInt32(Console.ReadLine());

            switch (quest)
            {
                case 1: return "UAH";
                case 2: return "USD";
                case 3: return "EUR";
                default: Console.WriteLine("Not Found"); break;
            }
            return "ХЗ";
        }

    }
}
