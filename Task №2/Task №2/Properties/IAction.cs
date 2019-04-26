using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__2
{
    interface IAction
    {
        void Add(ref List<Product> prod);
        void Remove(ref List<Product> prod);
        void Update(ref List<Product> prod);
        void Contains(List<Product> prod);
        void Search(List<Product> prod);
    }
}
