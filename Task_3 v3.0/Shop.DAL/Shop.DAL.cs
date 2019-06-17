using Shop.DAL.ADO;
using Shop.DAL.ADO.Contracts;
using Shop.DAL.ADO.Repositories;
using Shop.DAL.Contracts;
using Shop.DAL.Dtos.Products;
using Shop.DAL.Models;
using Shop.DAL.Models.Product_children;
using Shop.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


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
            ProductDto product = new ProductDto
            {
                Name = "Range",
                Description = "Description",
                Type = ProductType.Tablet,
                Price = 100000,
                CategoryId = 10
            };
            //ProductRepository prod = new ProductRepository();
            //ProductDto prodectdto = new ProductDto();
            //prodectdto = prod.GetById();
            //prodectdto.Show();
            EDMBaseRepository eDMBaseRepository = new EDMBaseRepository();
            eDMBaseRepository.DeleteProduct(5);

            Console.ReadLine();
        }
    }
}
