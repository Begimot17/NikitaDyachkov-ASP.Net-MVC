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
            Phones phone = new Phones("name","description","type",123,"manufact",5);
            Products<Phones> products = new Products<Phones>(phone);
            foreach (Phones ph in products)
            {
                Console.WriteLine(ph.Description );
            }
            Console.ReadLine();
        }
    }
}
