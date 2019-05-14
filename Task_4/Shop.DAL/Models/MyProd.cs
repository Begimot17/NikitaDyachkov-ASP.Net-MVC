using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{
    public class MyProd<TProd> where TProd :Product
    {
        public TProd obj;
        public MyProd(TProd obj)
        {
            this.obj = obj;
        }
    }
}
