using System.Collections.Generic;
namespace Task__2
{
    interface IProductRepository
    {
        void Add(List<Product> prod);
        void Remove(List<Product> prod);
        void Update(List<Product> prod);
        void Contains(List<Product> prod);
        void Search(List<Product> prod);
    }
}
