using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL.Contracts
{
    public class CartManager
    {
        public delegate void MethodContainer();
        public event MethodContainer Message;
        public void AddMessage()
        {
            Console.WriteLine("Add product to cart");
        }
        public void Add(string name)
        {
            MethodContainer method = AddMessage;
            Message = method;
            XmlManager xml = new XmlManager();
            Cart cart = new Cart();
            xml.setCart(name, cart.SelectProd());
            AddMessage();
        }
        public void Show(string name)
        {
            XmlManager xml = new XmlManager();
            Cart cart = new Cart();
            cart=xml.getCarts(name);
            cart.Show();
        }
        public void Remove(string name)
        {
            XmlManager xml = new XmlManager();
            Cart cart = new Cart();
            Console.WriteLine("Enter Delete Product");
            xml.RemoveProduct(name, Console.ReadLine());
        }
        public void Sort(string name)
        {
            XmlManager xml = new XmlManager();
            Cart cart = new Cart();
            cart=xml.getCarts(name);
            Console.WriteLine("1=Name\n2=Description\n3=Currency\n4=Price");
            int numsort = Int32.Parse(Console.ReadLine());
            cart.SortSet(numsort);
            cart.Sort();
            cart.Show();
        }
    }
}
