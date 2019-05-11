using System.Collections.Generic;

namespace Shop.DAL.Features.Cart.Contracts
{
    interface IProductRepository
    {
        bool Add(Product prod);
        bool Remove(string x);
        bool Update();
        List<Product> Contains();
        bool Search();
    }
}
