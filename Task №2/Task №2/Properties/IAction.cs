using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
