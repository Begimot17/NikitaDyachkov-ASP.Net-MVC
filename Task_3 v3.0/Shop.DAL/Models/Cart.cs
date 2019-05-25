using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{
    public enum SortBy : byte
    {
        Name = 1,
        Description = 2,
        Type = 3,
        Price = 4
    }
    
    public class Cart 
    {
        public string NameUser { get; set; }
        private List<Product> _products;
        public Product Product { get; set; }
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
        public SortBy SortBy { get; private set; }


        public Cart()
        {
            _products = new List<Product>();
        }

        public Cart(SortBy sortBy, IEnumerable<Product> collection)
        {
            SortBy = sortBy;
            _products = collection.ToList();
        }
        public Cart(string Name, Product prod)
        {
            NameUser = Name;
            Product = prod;
        }

        public List<Product> Contains()
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

        public bool Add(Product product)
        {
            _products.Add(product);
            return true;
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
    }
}
