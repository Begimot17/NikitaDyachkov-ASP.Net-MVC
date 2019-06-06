using Shop.DAL.Contracts;
using Shop.DAL.Models.Product_children;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL.Models
{
    public class Cart 
    {
        public string NameUser { get; set; }
        
        public Product Prod { get; set; }
        public List<Product> ProdList { get; set; }
        public static int TotalPrice { get; set; }
        public Cart()
        {
            
        }
        public Cart(string NameUser, List<Product> ProdList)
        {
            this.NameUser = NameUser;
            this.ProdList = ProdList;
        }
        public SortBy SortBy { get; private set; }
        public void Sort()
        {
            switch (SortBy)
            {
                case SortBy.Name:
                    ProdList= ProdList.OrderBy(x => x.Name).ToList();
                    break;
                case SortBy.Description:
                    ProdList = ProdList.OrderBy(x => x.Description).ToList();
                    break;
                case SortBy.Currency:
                    ProdList = ProdList.OrderBy(x => x.Currency).ToList();
                    break;
                case SortBy.Price:
                    ProdList = ProdList.OrderBy(x => x.Price).ToList();
                    break;
            }
        }
        public void SortSet(int sort)
        {
            switch(sort)
            {
                case 1: SortBy = SortBy.Name; break;
                case 2: SortBy = SortBy.Description; break;
                case 3: SortBy = SortBy.Currency; break;
                case 4: SortBy = SortBy.Price; break;
                default:return;
            }
        }
        public Product SelectProd()
        {
            XmlManager xml = new XmlManager();
            ProductsList productsList = new ProductsList();
            productsList = ProductsList.ProductListIni();
            productsList = xml.GetProducts(productsList);
            var i = 0;
            foreach (var item in productsList.products)
            {
                i++;
                Console.WriteLine($"{i,-3}{item.Name,-15}"+
                    $"{item.Manufactur,-15}{item.Description,-15}"+
                    $"{item.Price,-15}{item.Currency,-15}");
            }
            Console.WriteLine("Enter id Product");
            var quest=Int32.Parse(Console.ReadLine());
            var a = 0;
            foreach (var item in productsList.products)
            {
                a++;
                if (a == quest)
                    return item;
            }
            return null;
            
        }
        public void Show()
        {
            Cart car = new Cart();
            foreach (var item in ProdList)
            {
                item.Show();
            }
            Console.WriteLine(TotalPriceCount()+"---UAH");
        }
        public int TotalPriceCount()
        {
            foreach (var item in ProdList)
            {
                switch (item.Currency)
                {
                    case "UAH": TotalPrice += item.Price; ; break;
                    case "USD": TotalPrice += item.Price*26; ; break;
                    case "EUR": TotalPrice += item.Price*30; ; break;
                }
            }
            int total = TotalPrice;
            TotalPrice = 0;
            return total;
        }
    }
}
