using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_3.Class
{
    class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public Product() { }
        public Product(string Name, string Description, string Type, string Price)
        {
            this.Name = Name;
            this.Description = Description;
            this.Type = Type;
            this.Price = Price;
        }

        public static void ToList(string file, out List<Product> users)
        {
            users = new List<Product>();
            XDocument xdoc = XDocument.Load(file);
            foreach (XElement user in xdoc.Element("Employees").Elements("Employee"))
            {
                XAttribute prodName = user.Attribute("Name");
                XElement prodDesc = user.Element("Description");
                XElement prodType = user.Element("Type");
                XElement prodPrice = user.Element("Price");
                if (prodName != null && prodDesc != null && prodType != null && prodPrice != null)
                {
                    users.Add(new Product(prodName.Value, prodDesc.Value, prodType.Value, prodPrice.Value));
                }
            }
        }
        public static List<Product> ProdList()
        {
            List<Product> users = new List<Product>();
            string file = @"C:\Users\Хозяйн\source\repos\Task №3\Task №3\XML\Catalog.xml";
            ToList(file, out users);
            return users;
        }

    }
}
