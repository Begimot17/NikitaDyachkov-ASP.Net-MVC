using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3new
{
    interface IRepository
    {
        void AddProduct();
        void Update();
        void Delete();
        void Search();
        void Sort();
        void CatalogShow();
    }
}
