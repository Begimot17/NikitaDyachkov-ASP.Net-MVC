using System;
using System.Collections.Generic;
using Shop.DAL.Features.Cart;

namespace Task__2
{
    public class CartManager
    {
        public void AddToCatalog(params Product[] prod)
        {
            //TODO: Call CatalogRepository
            for (int i = 0; i < prod.Length; i++)
            {
                Console.Write("Enter Name: ");
                string Name = Console.ReadLine();
                Console.Write("Enter Description:");
                string Description = Console.ReadLine();
                Console.Write("Enter Type:");
                string Type = Console.ReadLine();
                Console.Write("Enter Price:");
                if (int.TryParse(Console.ReadLine(), out int Price))
                {
                    prod[i] = new Product(Name, Description, Type, Price);
                    Console.WriteLine("1=Add more\n2=Сonfirm");
                    int quest = 1;
                    if (int.TryParse(Console.ReadLine(), out quest) && quest == 2)
                        foreach (Product x in prod)
                        {
                            // TODO: FIx
                         //   if (x != null) CatalogRepository.Add(x);
                        }
                    break;
                }
            }
        }
        public static void Add(List <Product>catalog, Cart cart)
        {
                ShowProd(catalog);
                bool isNum = int.TryParse(Console.ReadLine(), out int quest);
                cart.Add(catalog[quest - 1]);
        }


        public static void ShowCart(Cart cart, int TotalPrice)
        {
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");

            foreach (Product x in cart.ListCart())
            {
                Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
            }
            Console.WriteLine($"TotalPrice={TotalPrice}");
        }

        public static void ShowProd(List<Product> _products)
        {
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");

            foreach (Product x in _products)
            {
                Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
            }
        }
        public static void RemoveProd(Cart cart)
        {
            Console.Write("Enter Name: ");
            cart.Remove(Console.ReadLine());
        }
    }
}
