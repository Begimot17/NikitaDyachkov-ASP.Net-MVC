using Shop.DAL.Contracts;
using Shop.DAL.Models.Product_children;
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
        
        public static SortBy SortBy { get; private set; }
        public static List<Product> Sort(List<Product> ProdList)
        {
            switch (SortBy)
            {
                case SortBy.Name:
                    ProdList = ProdList.OrderBy(x => x.Name).ToList();
                    break;
                case SortBy.Description:
                    ProdList = ProdList.OrderBy(x => x.Description).ToList();
                    break;
                case SortBy.Currency:
                    ProdList = ProdList.OrderBy(x => x.Currency).ToList();
                    break;
                case SortBy.Price:
                    ProdList = ProdList.OrderBy(x => x.Price).ToList();
                    break;
            }
            return ProdList;
        }
        public static void SortSet(int sort)
        {
            switch (sort)
            {
                case 1: SortBy = SortBy.Name; break;
                case 2: SortBy = SortBy.Description; break;
                case 3: SortBy = SortBy.Currency; break;
                case 4: SortBy = SortBy.Price; break;
                default: return;
            }
        }
        public static void ShowList(List<Product>ProdList)
        {
            foreach (var item in ProdList)
            {
                Console.WriteLine($"{item.Name,-15}{item.Manufactur,-15}{item.Description,-15}{item.Price,-15}{item.Currency,-15}");
            }
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
