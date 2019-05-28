using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models.Product_children
{
    class Phones:Product
    {
        string Manufacturer;
        int Ram;
        public Phones(string name, string description, string type, int price , string manufacturer, int ram) : base(name, description,type,price)
        {
            Manufacturer = manufacturer;
            Ram = ram;
        }

    }
}
