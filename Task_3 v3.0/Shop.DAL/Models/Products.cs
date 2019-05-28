using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{
    class Products<T>:IEnumerable where T:Product
    {
            T obj;
            public Products(T obj)
            {
                this.obj = obj;
            }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void objectType()
            {
                Console.WriteLine("Тип объекта: " + typeof(T));
            }
    }
}
