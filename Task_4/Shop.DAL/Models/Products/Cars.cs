using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models.Products
{
    class Cars : Product
    {
        public int Speed { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public Cars()
        {

        }
        public Cars(string name, string description, int price, char currency, int speed, string color, string type)
            : base(name, description, price, currency)
        {
            Speed = speed;
            Color = color;
            Type = type;
        }
    }
}
