using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Task_3new
{
    class Cart : IRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        string path = @"C:\Users\Хозяйн\source\repos\Task_3new\Task_3new\Xml\Cart.xml";
        public Cart() { }
        public Cart(int Id,string Name, string Description, string Type, int Price)
        {   this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Type = Type;
            this.Price = Price;
        }
        public void Create(string Name)
        {
            bool check = true;
            XDocument xDoc = XDocument.Load(path);
            foreach (XElement cart in xDoc.Element("Carts").Elements("User"))
            {
                XAttribute username = cart.Attribute("NameUser");
                if (username.ToString() == Name)
                    check = false;
            }
            if (check)
            {
                XNode xNewNode = new XElement("User", new XAttribute("NameUser", Name));
                xDoc.Root.Add(xNewNode);
                xDoc.Save(path);
            }
        }
        public List<Cart> CatalogToList()
        {
            Products temp = new Products();
            List<Cart> catalog = new List<Cart>();

            foreach (Products x in temp.ProductList())
            {
                catalog.Add(new Cart(catalog.Count + 1, x.Name, x.Description, x.Type, x.Price));
            }
            return catalog;
        }
        
        public void AddProduct()
        {
            CatalogShow();
            
            int quest=Convert.ToInt16(Console.ReadLine());
            foreach(Cart x in CatalogToList())
            {
                
            }
        }

        public void CatalogShow()
        {
            foreach (Cart x in CatalogToList())
            {
                Console.WriteLine("{0,-3}{1,-25}{2,-17}{3,-13}{4}", x.Id, x.Name, x.Description, x.Type, x.Price);
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
