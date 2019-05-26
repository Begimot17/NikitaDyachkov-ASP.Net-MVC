using Shop.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{[Serializable]
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public Product() { }
        static public SortBy SortBy { get; protected set; }
        public Product(string name, string description, string type, int price)
        {
            Name = name;
            Description = description;
            Type = type;
            Price = price;
        }



    }
}
