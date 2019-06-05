using Shop.DAL.Contracts;
using Shop.DAL.Models;
using Shop.DAL.Models.Product_children;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager prodman = new ProductManager();
            CartManager cartman = new CartManager();
            //prodman.Show(); 
            //cartman.Add("Nikita");
            cartman.Show("Nikita");
            cartman.Remove("Nikita");
            cartman.Show("Nikita");


            Console.ReadLine();
        }
    }
}
