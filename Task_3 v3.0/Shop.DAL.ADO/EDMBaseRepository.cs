using Shop.DAL.Dtos.Products;
using System.Linq;

namespace Shop.DAL.ADO
{
    public class EDMBaseRepository
    {
        protected ProductEntities GetContext()
        {
            return new ProductEntities();
        }
        public void Add(ProductDto product)
        {
            using (var context = GetContext())
            {
                var productEntity = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Type=product.Type,
                    CategoryId = product.CategoryId
                };
                context.Product.Add(productEntity);
                context.SaveChanges();
            }
        }
            public void DeleteProduct(int prodId)
            {
                using (var context = GetContext())
                {
                    var deleteProdItem = context.Product.FirstOrDefault(x => x.Id == prodId);
                    if (deleteProdItem != null)
                    {
                        context.Product.Remove(deleteProdItem);
                    }
                    context.SaveChanges();
                }
            }

        protected void UpdateProduct(ProductDto productForUpdate)
        {
            using (var context = GetContext())
            {
                var existitem = context.Product.FirstOrDefault(x => x.Id == productForUpdate.Id);
                existitem.Name = productForUpdate.Name;
                existitem.Description = productForUpdate.Description;
                existitem.Type = productForUpdate.Type;
                existitem.Price = productForUpdate.Price;
                existitem.CategoryId = productForUpdate.CategoryId;
                context.SaveChanges();
            }
        }

        protected void SearchProduct(string ProdName)
        {
            using (var context = GetContext())
            {
                context.Product.Where(x => x.Name == ProdName);
            }
        }
    }
}

