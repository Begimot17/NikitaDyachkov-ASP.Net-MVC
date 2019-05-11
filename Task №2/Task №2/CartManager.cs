using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public void Show()
        {
            Update();
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");

            foreach (Product x in _products)
            {
                Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
            }
            Console.WriteLine($"TotalPrice={TotalPrice}");
        }
    }
}
