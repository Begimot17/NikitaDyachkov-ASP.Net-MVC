using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Task__2
{
    class Cart : IEnumerable
    {
        private List<Product> _products;
        public static int TotalPrice { get; set; }
        public static List<Product> catalog = new List<Product>
            {
                new Product("Iphone SE 32gb", "Black", "Smartphone", 7999),
                new Product("Ipad PRO", "Silver", "Tablet", 50499),
                new Product("AirPods", "Black", "Headphones", 9749),
                new Product("Iphone XS MAX 512gb", "White", "Smartphone", 46999),
                new Product("Sennheiser MOMENTUM M2", "White", "Headphones", 6999),
                new Product("SAMSUNG Galaxy Tab", "Black", "Tablet", 5999)
            };
        public Product this[int index] {
            get
            {
                return _products[index];
            }
            set
            {
                try
                {
                    if (_products.Count < index)
                        _products[index] = value;
                    else
                        _products.Add(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        public Cart()
        {
            _products = new List<Product>();
        }

        public Cart(string sortBy, IEnumerable<Product> collection)
        {
            SortBy = sortBy;
            _products = collection.ToList();
        }
        public string SortBy { get; private set; }
        public void AddToCatalog(params Product[] prod)
        {
            for (int i = 0; i < prod.Length; i++)
            {
                Console.Write("Enter Name: ");
                string Name = Console.ReadLine();
                Console.Write("Enter Description:");
                string Description = Console.ReadLine();
                Console.Write("Enter Type:");
                string Type = Console.ReadLine();
                Console.Write("Enter Price:");
                int Price = Convert.ToInt32(Console.ReadLine());
                prod[i] = new Product(Name, Description, Type, Price);
                Console.WriteLine("1=Add more\n2=Сonfirm");
                int quest = Convert.ToInt16(Console.ReadLine());
                if (quest == 2)
                {
                    foreach (Product x in prod)
                    {
                        if (x != null) catalog.Add(x);
                    }
                    break;
                }
            }
        }
        public void Remove()
        {
            Console.Write("Enter Name: ");
            string prodToDelete = Console.ReadLine();
            for (int i = 0; i < _products.Count; i++)
            {
                foreach (Product x in _products)
                {
                    if (x.Name == prodToDelete)
                    {
                        _products.Remove(x);
                        break;
                    }
                }
            }
        }
        public void Update()
        {
            Sort();
            Total();
        }
        public void Head()
        {
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");
        }
        public void Contains()
        {
            Update();
            Head();
            foreach (Product x in _products)
            {

                Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
            }
            Console.WriteLine($"TotalPrice={TotalPrice}");
        }
        public void Search()
        {
            Console.WriteLine("Search by 1=Name 2=Description");
            int quest = Convert.ToInt16(Console.ReadLine());
            if (quest == 1)
            {
                Console.Write("Enter Name: ");
                string prodToSearch = Console.ReadLine();
                foreach (Product x in catalog)
                {
                    string test;
                    test = x.Name.Replace(prodToSearch, " ");
                    if (test != x.Name)
                    {
                        Head();
                        Product.Show(x);
                    }
                }
            }
            else if (quest == 2)
            {
                Console.Write("Enter Description: ");
                string prodToSearch = Console.ReadLine();
                foreach (Product x in catalog)
                {
                    string test;
                    test = x.Description.Replace(prodToSearch, " ");
                    if (test != x.Description)
                    {
                        Head();
                        Product.Show(x);
                    }
                }
            }
        }
        public void Sort()
        {
            switch (SortBy)
            {
                case "Name": catalog = catalog.OrderBy(x => x.Name).ToList(); break;
                case "Description": catalog = catalog.OrderBy(x => x.Description).ToList(); break;
                case "Type": catalog = catalog.OrderBy(x => x.Type).ToList(); break;
                case "Price": catalog = catalog.OrderBy(x => x.Price).ToList(); break;
            }
        }
        public void SortToСhange()
        {
            Console.WriteLine("Sort by 1=Name/2=Description/3=Type/4=Price");
            int quest = Convert.ToInt16(Console.ReadLine());
            switch (quest)
            {
                case 1: SortBy = "Name"; break;
                case 2: SortBy = "Description"; break;
                case 3: SortBy = "Type"; break;
                case 4: SortBy = "Price"; break;
            }
            Sort();

        }
        public void Total()
        {
            int total = 0;
            foreach (Product x in _products)
            {
                total += x.Price;
            }
            TotalPrice = total;
        }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void CatalogShow()
        {
            int i = 1;
            Console.WriteLine($"{"ID",-3} {"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");
            foreach (Product x in catalog)
            {
                Console.WriteLine($"{i,-3} {x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
                i++;
            }
        }
        public void AddToCart()
        {
            while (true)
            {
                CatalogShow();
                
                int quest = Convert.ToInt32(Console.ReadLine());
                switch (quest)
                {
                    case 1: _products.Add(catalog[0]); break;
                    case 2: _products.Add(catalog[1]); break;
                    case 3: _products.Add(catalog[2]); break;
                    case 4: _products.Add(catalog[3]); break;
                    case 5: _products.Add(catalog[4]); break;
                    case 6: _products.Add(catalog[5]); break;
                    default: Console.WriteLine("Wrong input"); break;
                }
                Console.WriteLine("1=Add more\n2=Сonfirm");
                int quest2 =Convert.ToInt32(Console.ReadLine());
                if (quest2 == 2)
                {
                    break;
                }
            }
        }
    }
}
