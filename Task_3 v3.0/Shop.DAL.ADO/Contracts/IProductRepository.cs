using Shop.DAL.Dtos.Products;
using System;
using System.Collections.Generic;

namespace Shop.DAL.ADO.Contracts
{
    public interface IProductRepository
    {
        void Create(ProductDto product);
        void Update(ProductDto product);
        void Delete(int id);
        IEnumerable<ProductDto> Get();
        ProductDto GetById();
    }
}
