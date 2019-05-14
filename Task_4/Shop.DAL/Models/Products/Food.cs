using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models.Products
{
    class Food:Product
    {
        public int Kkal { get; set; }
        public string Type { get; set; }
        public Food()
        {

        }
        public Food(string name, string description, int price, char currency, int kkal, string type)
            : base(name, description, price, currency)
        {
            Kkal = kkal;
            Type = type;
        }
    }
}
