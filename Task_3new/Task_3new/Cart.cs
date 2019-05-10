using System;
namespace Task_3new
{
    public class Cart
    {
        public string NameUser { get; set; }
        public string NameProd { get; set; }
        public string DiscProd { get; set; }
        public string TypeProd { get; set; }
        public decimal PriceProd { get; set; }
        readonly string pathProd = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3new\Task_3new\Xml\Product.xml";
        readonly string path = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3new\Task_3new\Xml\Cart.xml";
        public Cart( ) { }
        public Cart(string NameUser) { }
        public Cart(string NameUser, string NameProd, string DiscProd, string TypeProd, decimal PriceProd)
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
            foreach(Products x in XmlManager.ProductList(pathProd))
            {
                if (counter == numProd)
                    prod = (new Products(x.Name, x.Description, x.Type, x.Price));
                    counter++;
            }
            if (XmlManager.AddProduct(Name, prod, path))
                Console.WriteLine("Product added");
            
        }
        public void CatalogShow()
        {
            Products prod = new Products();
            int i = 1;
            foreach (Products x in XmlManager.ProductList(pathProd))
            {
                Console.WriteLine("{0,-3}{1,-25}{2,-17}{3,-13}{4}", i++, x.Name, x.Description, x.Type, x.Price);
            }
        }
        public void CartShow(string Name)
        {
            decimal AllPrice=0;
            Console.WriteLine("Your Cart");
            foreach (Cart x in XmlManager.CartsList(Name , path))
            {
                Console.WriteLine("{0,-25}{1,-25}{2,-17}{3,-13}", x.NameProd, x.DiscProd, x.TypeProd, x.PriceProd);
                AllPrice += x.PriceProd;
            }
            Console.WriteLine($"AllPrice={AllPrice}");
        }

        public void Search()
        {
            Products prod = new Products();
            Console.WriteLine("Enter name to search");
            string namesearch = Console.ReadLine();
            int num = 1;
            foreach (Products x in XmlManager.ProductList(pathProd))
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
