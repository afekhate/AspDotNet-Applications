using SportsMarket.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsMarket.WebUI.Models;

namespace SportsMarket.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRespository repository { get; set; }
        public int Pagesize = 4; 

        public ProductController(IProductRespository productRespository)
        {
            this.repository = productRespository;
        }
        // GET: Product
        public ViewResult List(string category , int Page = 1)
        {
            ProductListViewModel model = new ProductListViewModel()
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((Page - 1) * Pagesize)
                .Take(Pagesize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = Page,
                    ItemsPerpage = Pagesize,
                    TotalItems = category == null ? repository.Products.Count()
                    : repository.Products.Where(a => a.Category == category).Count()
                },
                CurrentCategory = category

            };
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            var prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
           
        }
    }
}