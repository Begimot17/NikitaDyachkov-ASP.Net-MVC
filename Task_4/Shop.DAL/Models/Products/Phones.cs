using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models.Products
{
    public class Phones : Product
    {
        public int Memory { get; set; }
        public string Color { get; set; }
        public Phones()
        {

        }
        public Phones(string name, string description, int price, char currency,int memory, string color)
            : base ( name, description, price, currency)
        {
            Memory = memory;
            Color = color;
        }
    }
}
