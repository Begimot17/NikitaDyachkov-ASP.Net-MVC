using Shop.DAL.Contracts;
using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            CartManager cart = new CartManager();
            cart.ShowCarts("Nikita");
            
            Console.ReadLine();
        }
    }
}
