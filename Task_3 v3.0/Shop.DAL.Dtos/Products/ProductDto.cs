using Shop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Dtos.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable <decimal> Price { get; set; }
        public ProductType Type { get; set; }
        public int CategoryId { get; set; }
        public void Show()
        {
            Console.WriteLine($"Id-{Id,-5}Name-{Name,-10}Description-{Description,-20}Price-{Price,10}" +
                $"Type-{Type.ToString(),-10}CategoryId-{CategoryId,-5}");
        }
    }
}
