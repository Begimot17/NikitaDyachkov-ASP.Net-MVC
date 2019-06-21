using Shop.DAL.ADO;
using Shop.DAL.ADO.Repositories;
using Shop.DAL.Dtos.Products;
using Shop.Enums;
using System;
using System.Collections.Generic;


namespace Shop.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            //IProductRepository repository = new ProductRepository();
            //foreach (var item in repository.Get())
            //{
            //    Console.WriteLine($"Id category-{item.CategoryId,-15}Desc-{item.Description,15}" +
            //        $"id-{item.Id,-15}Name-{item.Name,-15}Price-{item.Price,-15}Type-{item.Type.ToString(),-15}");
            //}
            ProductDto prodectdto = new ProductDto {
                Name = "Name",
                Description = "Desc",
                Type = ProductType.Smartphone,
                Price = 10000
                
                
            };
            

            EDMBaseRepository eDMBaseRepository = new EDMBaseRepository();
            eDMBaseRepository.Add(prodectdto);

            //prodectdto.Show();


            Console.ReadLine();
        }
    }
}
