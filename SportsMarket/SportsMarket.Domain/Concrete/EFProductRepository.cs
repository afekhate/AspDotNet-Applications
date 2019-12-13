using SportsMarket.Domain.Abstract;
using SportsMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsMarket.Domain.Concrete
{
    public class EFProductRepository : IProductRespository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products 
        {
            get { return context.Products; }    
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                var productInDb = context.Products.Find(product.ProductID);
                if(productInDb != null)
                {
                    productInDb.Category = product.Category;
                    productInDb.Description = product.Description;
                    productInDb.Name = product.Name;
                    productInDb.Price = product.Price;
                    productInDb.ImageData = product.ImageData;
                    productInDb.ImageMimeType = product.ImageMimeType;


                }
                context.SaveChanges();
            }
            
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
       
    }
}
