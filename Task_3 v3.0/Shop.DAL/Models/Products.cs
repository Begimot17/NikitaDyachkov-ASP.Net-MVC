using Shop.DAL.Models.Product_children;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{
    class Products<T> where T:Product
    {

        T obj;
        public Products()
        {
        }
        public Products(T obj)
        {
            this.obj = obj;
        }

        public void objectType()
        {
            Console.WriteLine("Тип объекта: " + typeof(T));
        }
        public void ShowProduct(T obj)
        {
            Car car = new Car();
            Phone phone = new Phone();
            Sneakers sneakers = new Sneakers();
            if (obj.GetType() == car.GetType())
            {
                car = (Car)(object)obj;
                car.Show();
            }
            else if (obj.GetType() == phone.GetType())
            {
                phone = (Phone)(object)obj;
                phone.Show();
            }
            else if (obj.GetType() == sneakers.GetType())
            {
                sneakers = (Sneakers)(object)obj;
                sneakers.Show();
            }
        }
    }
}
