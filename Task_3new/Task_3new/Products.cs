using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_3new
{
    class Products : IRepository
    {
        public string Name { get; set; }
        public string Description{ get; set; }
        public string Type{ get; set; }
        public int Price{ get; set; }
        public string SortBy { get; private set; }
        public List<Products> ProdList ;
        string path = @"C:\Users\Хозяйн\source\repos\Task_3new\Task_3new\Xml\Product.xml";
        public Products() { }
        public Products(string Name, string Description, string Type, int Price)
        {
            this.Name = Name;
            this.Description = Description;
            this.Type = Type;
            this.Price = Price;
        }
        public void AddProduct()
        {
            Update();
            Products product = new Products();
            Console.Write("Enter Name->");
            product.Name = Console.ReadLine();
            Console.Write("Enter Description->");
            product.Description = Console.ReadLine();
            Console.Write("Enter Type->");
            product.Type = Console.ReadLine();
            Console.Write("Enter Price->");
            product.Price = Convert.ToInt16(Console.ReadLine());
            XDocument xDoc = XDocument.Load(path);
            XNode xNewNode = new XElement("Product", new XAttribute("Name", product.Name),
                new XElement("Description", product.Description),
                new XElement("Type", product.Type),
                new XElement("Price", product.Price));
            xDoc.Root.Add(xNewNode);
            xDoc.Save(path);
            Update();

        }

        public void Delete()
        {
            Update();
            Console.WriteLine("Enter name delete");
            string nameDelete = Console.ReadLine();
            XDocument xDoc = XDocument.Load(path);
            foreach (XElement xNode in xDoc.Root.Nodes())
            {
                if (xNode.Attribute("Name").Value == nameDelete)
                {
                    xNode.Remove();
                }
            }
            xDoc.Save(path);
            Update();

        }

        public void Search()
        {
            Update();
            Console.WriteLine("Enter name to search");
            string namesearch=Console.ReadLine();
            foreach(Products x in ProductList())
            {
                if (x.Name == namesearch)
                {
                    Console.WriteLine("{0} {1} {2} {3}",x.Name, x.Description, x.Type, x.Price);
                }
            }

        }
        public void SortChange()
        {
            Update();
            Console.WriteLine("Sort\n1=Name\n2=Description\n3=Type\n4=Price");
            switch (Convert.ToInt16(Console.ReadLine()))
            {
                case 1: SortBy="Name"; break;
                case 2: SortBy="Description"; break;
                case 3: SortBy="Type"; break;
                case 4: SortBy="Price"; break;
            }
            Sort();
            
        }
        public void Sort()
        {
            switch (SortBy)
            {
                case "Name": ProdList = ProdList.OrderBy(x => x.Name).ToList(); break;
                case "Description": ProdList = ProdList.OrderBy(x => x.Description).ToList(); break;
                case "Type": ProdList = ProdList.OrderBy(x => x.Type).ToList(); break;
                case "Price": ProdList = ProdList.OrderBy(x => x.Price).ToList(); break;
            }
            foreach (Products x in ProdList)
            {
                Console.WriteLine("{0,-24} {1,-10} {2,-10} {3,-10}", x.Name, x.Description, x.Type, x.Price);
            }
        }
        public void Update()
        {
            ProdList = ProductList();
        }

        public List<Products> ProductList()
        {
            List<Products> product = new List<Products>();
            XDocument xdoc = XDocument.Load(path);
            foreach (XElement prod in xdoc.Element("Products").Elements("Product"))
            {
                XAttribute Name = prod.Attribute("Name");
                XElement Description = prod.Element("Description");
                XElement Type = prod.Element("Type");
                XElement Price = prod.Element("Price");


                if (Name != null && Description != null && Type != null&& Price != null)
                {
                    product.Add(new Products(Name.Value, Description.Value, Type.Value, Convert.ToInt32(Price.Value)));
                }
            }
            return product;
        }
        public void CatalogShow()
        {
            Update();
            foreach (Products x in ProdList)
            {
                Console.WriteLine("{0,-24} {1,-10} {2,-10} {3,-10}",x.Name, x.Description, x.Type, x.Price);
            }
        }
        
    }
}
