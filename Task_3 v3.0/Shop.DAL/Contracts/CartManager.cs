using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL.Contracts
{
    public class CartManager
    {
        string fileProduct = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3 v3.0\Shop.DAL\Repositories\Products.xml";
        string fileCart = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3 v3.0\Shop.DAL\Repositories\Carts.xml";
        public  void Sort(Cart cart)
        {
            Console.WriteLine("Sort by 1=Name/2=Description/3=Type/4=Price");
            string sortby = "Name";
            bool isNum = int.TryParse(Console.ReadLine(), out int quest);
            switch (quest)
            {
                case 1: sortby = "Name"; break;
                case 2: sortby = "Description"; break;
                case 3: sortby = "Type"; break;
                case 4: sortby = "Price"; break;
                default: return;
            }
            SortBy sort;
            Enum.TryParse(sortby, true, out sort);
            cart.SetSort(sort);
        }
        public  void Add(string Name)
        {
            

            XmlManager xmlman = new XmlManager();

            ProductManager prodman = new ProductManager();
            prodman.CatalogShow();
            Product prod = null;
            List<Product> ProdList = xmlman.DisProd(fileProduct).ToList();
            int i = 1;
            int quest = Convert.ToInt32(Console.ReadLine());
            foreach (Product x in ProdList)
            {
                if (i == quest)
                    prod = new Product(x.Name, x.Description, x.Type, x.Price);
                i++;
            }
            if (prod == null)
                return;
            xmlman.AddProduct(Name,prod,fileCart);
        }
        public  void CartShow(string Name)
        {
            XmlManager xmlman = new XmlManager();
            decimal AllPrice = 0;
            Console.WriteLine("Your Cart");
            List<Cart> CartList = xmlman.CartsList(Name, fileCart);
            foreach (Cart x in CartList)
            {
                Console.WriteLine("{0,-25}{1,-25}{2,-17}{3,-13}", x.Product.Name, x.Product.Description, x.Product.Type, x.Product.Price);
                AllPrice += x.Product.Price;
            }
            Console.WriteLine($"AllPrice={AllPrice}");
        }
        public  void ShowCart(Cart cart, int TotalPrice)
        {
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");

            foreach (Product x in cart.Contains())
            {
                Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
            }
            Console.WriteLine($"TotalPrice={TotalPrice}");
        }
        public  void RemoveProd(Cart cart)
        {

            Console.Write("Enter Name: ");
            cart.Remove(Console.ReadLine());
        }
        public  void RemoveProd(string Name)
        {
            XmlManager xmlman = new XmlManager();
            CartShow(Name);
            Console.Write("Enter Name: ");
            xmlman.RemoveProduct(Name, Console.ReadLine(), fileCart);
        }
    }
}
