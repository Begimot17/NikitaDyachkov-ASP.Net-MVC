using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL.Contracts
{
    public class CartManager
    {
        public void Add(string name)
        {
            XmlManager xml = new XmlManager();
            Cart cart = new Cart();
            xml.setCart(name, cart.SelectProd());
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
        public void InfoId(string name)
        {
            XmlManager xml = new XmlManager();
            Cart cart = new Cart();
            Console.WriteLine("Enter Delete Product");
            xml.RemoveProduct(name, Console.ReadLine());
        }

    }
}
