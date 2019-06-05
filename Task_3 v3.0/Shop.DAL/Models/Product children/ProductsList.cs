using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models.Product_children
{
    public class ProductsList
    {
        public List<Product> products { get; set; }
        public List<Car> cars { get; set; }
        public List<Phone> phones { get; set; }
        public List<Sneakers> sneakers { get; set; }
        public static ProductsList ProductListIni()
        {
            ProductsList productsList = new ProductsList();
            productsList.phones = new List<Phone>();
            productsList.sneakers = new List<Sneakers>();
            productsList.cars = new List<Car>();
            productsList.products = new List<Product>();
            return productsList;
        }
    }
}
