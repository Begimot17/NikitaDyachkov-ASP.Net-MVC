using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Task_3new
{
    public class Cart
    {
        public string NameUser { get; set; }
        public string NameProd { get; set; }
        public string DiscProd { get; set; }
        public string TypeProd { get; set; }
        public decimal PriceProd { get; set; }

        readonly string path = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3new\Task_3new\Xml\Cart.xml";
        public Cart( ) { }
        public Cart(string NameUser) { }
        Cart(string NameUser, string NameProd, string DiscProd, string TypeProd, decimal PriceProd)
        {
            this.NameUser = NameUser;
            this.NameProd = NameProd;
            this.DiscProd = DiscProd;
            this.TypeProd = TypeProd;
            this.PriceProd = PriceProd;
        }
        public void AddProduct(string Name)
        {
            CatalogShow();
            Products prod = new Products();
            Console.WriteLine("Enter number product");
            int numProd=Convert.ToInt16(Console.ReadLine());
            int counter=1;
            foreach(Products x in prod.ProductList())
            {
                if (counter == numProd)
                    prod = (new Products(x.Name, x.Description, x.Type, x.Price));
                    counter++;
            }
            XDocument xdoc = XDocument.Load(path);
            xdoc.Root.Add(new XElement("Cart",
            new XAttribute("NameUser", Name),
            new XElement("Name", prod.Name),
            new XElement("Discription", prod.Description),
            new XElement("Type", prod.Type),
            new XElement("Price", prod.Price)));
            xdoc.Save(path);

        }
        public List<Cart> CartsList(string NameUs)
        {
            List<Cart> cart = new List<Cart>();
            XDocument xdoc = XDocument.Load(path);
            foreach (XElement prod in xdoc.Element("Carts").Elements("Cart"))
            {
                XAttribute NameUser = prod.Attribute("NameUser");
                XElement Name = prod.Element("Name");
                XElement Discription = prod.Element("Discription");
                XElement Type = prod.Element("Type");
                XElement Price = prod.Element("Price");
                if (NameUser.Value == NameUs)
                    cart.Add(new Cart(NameUser.Value, Name.Value, Discription.Value, Type.Value,  Convert.ToDecimal(Price.Value)));
            }
                return cart;
        }
        public void CatalogShow()
        {
            Products prod = new Products();
            int i = 1;
            foreach (Products x in prod.ProductList())
            {
                Console.WriteLine("{0,-3}{1,-25}{2,-17}{3,-13}{4}", i++, x.Name, x.Description, x.Type, x.Price);
            }
        }
        public void CartShow(string Name)
        {
            decimal AllPrice=0;
            Console.WriteLine("Your Cart");
            foreach (Cart x in CartsList(Name))
            {
                Console.WriteLine("{0,-25}{1,-25}{2,-17}{3,-13}", x.NameProd, x.DiscProd, x.TypeProd, x.PriceProd);
                AllPrice += x.PriceProd;
            }
            Console.WriteLine($"AllPrice={AllPrice}");
        }

        public void Delete(string Name)
        {
            Console.WriteLine("Enter name delete");
            string nameDelete = Console.ReadLine();
            XDocument xDoc = XDocument.Load(path);
            foreach (XElement xNode in xDoc.Root.Nodes())
            {
                if (xNode.Element("Name").Value == nameDelete&& xNode.Attribute("NameUser").Value == Name)
                {
                    xNode.Remove();
                    break;
                }
            }
            xDoc.Save(path);
        }
        public void Search()
        {
            Products prod = new Products();
            Console.WriteLine("Enter name to search");
            string namesearch = Console.ReadLine();
            int num = 1;
            foreach (Products x in prod.ProductList())
            {
                if (x.Name == namesearch)
                {
                    Console.WriteLine("{0} {1} {2} {3}",num, x.Name, x.Description, x.Type, x.Price);
                }
                num++;
            }
        }

    }
}
