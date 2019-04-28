using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__2
{
    class Cart : IEnumerable
    {
        private List<Product> _products;
        public static int TotalPrice { get; set; }

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
            _products = new List<Product> ();
        }

        public Cart(string sortBy, IEnumerable<Product> collection)
        {
            SortBy = sortBy;
            _products = collection.ToList() ;
        }


        public string SortBy { get; private set; }
        public void Add(params Product[] prod)
        {
            for(int i=0;i<prod.Length;i++)
            {
                Console.Write("Введите названия: ");
                string Name = Console.ReadLine();


                Console.Write("Введите описание:");
                string Description = Console.ReadLine();


                Console.Write("Введите тип:");
                string Type = Console.ReadLine();


                Console.Write("Введите цену продукта:");
                int Price = Convert.ToInt32(Console.ReadLine());
                prod[i] = new Product(Name, Description, Type, Price);

                Console.WriteLine("1=Добавить еще\n2=Готово");
                int quest =Convert.ToInt16(Console.ReadLine());
                if (quest == 2)
                {
                    foreach (Product x in prod)
                    {
                        if (x != null)  _products.Add(x); 
                    }
                    break;
                }
            }
                 
            
            
            
            
        }
        public void Remove()
        {
            Console.WriteLine("Введите имя продукта");
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
        public void Contains()
        {

            Update();
            Console.WriteLine($"Name    Description    Type    Price");
            foreach (Product x in _products)
            {

                Console.WriteLine($"{x.Name}    {x.Description}    {x.Type}    {x.Price}");
            }
            Console.WriteLine($"TotalPrice={TotalPrice}");

        }
        public void Search()
        {
            Console.WriteLine("Поиск по 1=Имени 2=Описанию");
            int quest=Convert.ToInt16(Console.ReadLine());
            if (quest == 1)
            {
                Console.WriteLine("Введите имя продукта");
                string prodToSearch = Console.ReadLine();
                foreach (Product x in _products)
                {
                    string test;
                    test = x.Name.Replace(prodToSearch, " ");
                    if (test != x.Name)
                        Product.Show(x);
                }
            }
            else if (quest == 2)
            {
                Console.WriteLine("Введите описание продукта");
                string prodToSearch = Console.ReadLine();
                foreach (Product x in _products)
                {
                    string test;
                    test = x.Description.Replace(prodToSearch, " ");
                    if (test != x.Description)
                        Product.Show(x);
                }
            }
        }
        public void Sort()
        {
            switch (SortBy)
            {
                case "Name": _products = _products.OrderBy(x => x.Name).ToList(); break;
                case "Description": _products = _products.OrderBy(x => x.Description).ToList(); break;
                case "Type": _products = _products.OrderBy(x => x.Type).ToList(); break;
                case "Price": _products = _products.OrderBy(x => x.Price).ToList(); break;
            }
        }
        public void SortToСhange()
        {
            Console.WriteLine("По какому полю будем сортировать 1=Name/2=Description/3=Type/4=Price");
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
            int total=0;
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
    }
}
