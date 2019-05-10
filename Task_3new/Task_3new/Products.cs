using System;
using System.Collections.Generic;
using System.Linq;
namespace Task_3new

{
    public class Products : IRepository
    {
        public string Name { get; set; }
        public string Description{ get; set; }
        public string Type{ get; set; }
        public int Price{ get; set; }
        string SortBy { get; set; }
        public List<Products> ProdList ;
        readonly string path = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3new\Task_3new\Xml\Product.xml";
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
            if (XmlManager.AddProduct(path, product))
                Console.WriteLine("Product Added");
            Update();

        }

        public void Delete()
        {
            Update();
            Console.WriteLine("Enter name delete");
            string nameDelete = Console.ReadLine();
            if(XmlManager.Remove(path , nameDelete))
                Console.WriteLine("Product Removed");
            Update();

        }

        public void Search()
        {
            Update();
            Console.WriteLine("Enter name to search");
            string namesearch=Console.ReadLine();
            foreach(Products x in XmlManager.ProductList(path))
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
            ProdList = XmlManager.ProductList(path);
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
