using Shop.DAL.ADO.Contracts;
using Shop.DAL.ADO.Entities;
using Shop.DAL.Dtos.Products;
using Shop.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Shop.DAL.ADO.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public void Create(ProductDto product)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();

                string query = $"Insert Into Product(Name," +
                    $"Description, Type , Price , CategoryId) " +
                    $"Values('{product.Name}','{product.Description}','{product.Type}','{product.Price}','{product.CategoryId}')";
                SqlCommand getProductsCommand = new SqlCommand(query, cn);
                getProductsCommand.ExecuteReader(CommandBehavior.Default);
                cn.Close();
            }
        }

        private string ReadString(SqlDataReader reader, string key) => reader[key].ToString();

        public IEnumerable<ProductDto> Get()
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                string query = "SELECT * FROM Product";
                SqlCommand getProductsCommand = new SqlCommand(query, cn);
                SqlDataReader productsDataReader = getProductsCommand.ExecuteReader(CommandBehavior.Default);
                var result = new List<Product>();

                while (productsDataReader.Read())
                {
                    ProductType type;
                    Enum.TryParse(productsDataReader[nameof(Product.Type)].ToString(), out type);
                    var product = new Product
                    {
                        CategoryId = Int32.Parse(ReadString(productsDataReader, nameof(Product.CategoryId))),
                        Description = productsDataReader[nameof(Product.Description)].ToString(),
                        Id = Int32.Parse(ReadString(productsDataReader, nameof(Product.Id))),
                        Name = ReadString(productsDataReader, nameof(Product.Name)),
                        Price = decimal.Parse(ReadString(productsDataReader, nameof(Product.Price))),
                        Type = type
                    };

                    result.Add(product);
                }

                productsDataReader.Close();
                cn.Close();
                return result.Select(x => new ProductDto
                {
                    Type = x.Type,
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                });
            }
        }

        public ProductDto GetById()
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                string query = "SELECT * FROM Product";
                SqlCommand getProductsCommand = new SqlCommand(query, cn);
                SqlDataReader productsDataReader = getProductsCommand.ExecuteReader(CommandBehavior.Default);
                Console.WriteLine("Enter id");
                while (productsDataReader.Read())
                {
                    int Id = Int32.Parse(ReadString(productsDataReader, nameof(Product.Id)));
                      string   Name = ReadString(productsDataReader, nameof(Product.Name));
                    Console.WriteLine($"Id-{Id,-5}Name-{Name}");

                }
                var product=new ProductDto();
                productsDataReader.Close();
                var enter = Int32.Parse(Console.ReadLine());
                SqlCommand getProductsCommand2= new SqlCommand(query, cn);
                SqlDataReader productsDataReader2 = getProductsCommand2.ExecuteReader(CommandBehavior.Default);
                while (productsDataReader2.Read())
                {
                    int id = Int32.Parse(ReadString(productsDataReader2, nameof(Product.Id)));
                    if (id == enter)
                    {
                        ProductType type;
                        Enum.TryParse(productsDataReader2[nameof(Product.Type)].ToString(), out type);
                        product = new ProductDto
                        {
                            CategoryId = Int32.Parse(ReadString(productsDataReader2, nameof(Product.CategoryId))),
                            Description = productsDataReader2[nameof(Product.Description)].ToString(),
                            Id = Int32.Parse(ReadString(productsDataReader2, nameof(Product.Id))),
                            Name = ReadString(productsDataReader2, nameof(Product.Name)),
                            Price = decimal.Parse(ReadString(productsDataReader2, nameof(Product.Price))),
                            Type = type
                        };
                        break;
                    }
                }
                productsDataReader2.Close();
                cn.Close();
                return product;
            }
        }

        public void Update(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                string query = $"DELETE FROM Product Where Id={id}";
                SqlCommand getProductsCommand = new SqlCommand(query, cn);
                getProductsCommand.ExecuteReader(CommandBehavior.Default);
                cn.Close();
            }
        }
    }
}
