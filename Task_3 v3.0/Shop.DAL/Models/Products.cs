using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{
    [Serializable]
    class Products<T>:IEnumerable where T:Product
    {
        
            T obj;
        [NonSerialized]
            List<T> list=new List<T>();
            public Products(T obj)
            {
                this.obj = obj;
            list.Add(obj);
            }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public void objectType()
            {
                Console.WriteLine("Тип объекта: " + typeof(T));
            }
    }
}
