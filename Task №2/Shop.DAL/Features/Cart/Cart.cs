using Shop.DAL.Features.Cart.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL.Features.Cart
{


    public enum SortBy : byte
    {
        Name = 1,
        Description = 2,
        Type = 3,
        Price = 4
    }

    public class Cart : IEnumerable, IProductRepository
    {
        private List<Product> _products;
        public static int TotalPrice { get; set; }
        public Product this[int index]
        {
            get
            {
                return _products[index];
            }
            set
            {
                if (_products.Count < index)
                    _products[index] = value;
                else
                    _products.Add(value);
            }
        }
        public Cart()
        {
            _products = new List<Product>();
        }

        public Cart(SortBy sortBy, IEnumerable<Product> collection)
        {
            SortBy = sortBy;
            _products = collection.ToList();
        }

        public SortBy SortBy { get; private set; }

        public List<Product> ListCart()
        {
            return _products;
        }
        public void Sort()
        {
            switch (SortBy)
            {
                case SortBy.Name:
                    _products = _products.OrderBy(x => x.Name).ToList();
                    break;
                case SortBy.Description:
                    _products = _products.OrderBy(x => x.Description).ToList();
                    break;
                case SortBy.Type:
                    _products = _products.OrderBy(x => x.Type).ToList();
                    break;
                case SortBy.Price:
                    _products = _products.OrderBy(x => x.Price).ToList();
                    break;
            }
        }

        public void SetSort(SortBy sortType)
        {
            //Console.WriteLine("Sort by 1=Name/2=Description/3=Type/4=Price");
            //SortBy sort;
            //Enum.TryParse("from readline", true, out sort);
            // bool isNum = int.TryParse(Console.ReadLine(), out int quest);


            //switch (quest)
            //{
            //    case 1: SortBy = "Name"; break;
            //    case 2: SortBy = "Description"; break;
            //    case 3: SortBy = "Type"; break;
            //    case 4: SortBy = "Price"; break;
            //    default: return;
            //}
            SortBy = sortType;

            Sort();
        }

        public int Total()
        {
            int total = 0;
            foreach (Product x in _products)
            {
                total += x.Price;
            }
            TotalPrice = total;
            return TotalPrice;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //public void CatalogShow()
        //{
        //    int i = 1;
        //    Console.WriteLine($"{"ID",-3} {"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");
        //    foreach (Product x in catalog)
        //    {
        //        Console.WriteLine($"{i,-3} {x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
        //        i++;
        //    }
        //}

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public bool Remove(string prodToDelete)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                foreach (Product x in _products)
                {
                    if (x.Name == prodToDelete)
                    {
                        _products.Remove(x);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Update()
        {
            Sort();
            Total();
            return true;
        }

        public bool Search(string prodToSearch)
        {
            Console.WriteLine("Search by 1=Name 2=Description");
            bool isNum = int.TryParse(Console.ReadLine(), out int quest);

            if (quest == 1)
            {
                Console.Write("Enter Name: ");
                prodToSearch = Console.ReadLine();
                foreach (Product x in _products)
                {
                    if (x.Name.Replace(prodToSearch, " ") != x.Name)
                    {
                        //ConsoleOutput.ShowProduct(x);
                    }
                }
            }
            else if (quest == 2)
            {
                Console.Write("Enter Description: ");
                prodToSearch = Console.ReadLine();
                //foreach (Product x in catalog)
                //{
                //    if (x.Description.Replace(prodToSearch, " ") != x.Description)
                //    {
                //        ConsoleOutput.ShowProduct(x);
                //    }
                //}
            }
            return true;
        }

        public bool Search()
        {
            throw new NotImplementedException();
        }

        public bool Add()
        {
            throw new NotImplementedException();
        }

        public bool Remove()
        {
            throw new NotImplementedException();
        }
    }
}
