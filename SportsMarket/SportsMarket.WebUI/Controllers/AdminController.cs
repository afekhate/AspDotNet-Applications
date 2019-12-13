using SportsMarket.Domain.Abstract;
using SportsMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsMarket.Domain.Concrete;

namespace SportsMarket.WebUI.Controllers
{
    
    public class AdminController : Controller
    {
        public IProductRespository repository { get; set; }

        public AdminController(IProductRespository repo)
        {
            this.repository = repo;
        }
        // GET: Admin
       
        public ActionResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Edit(int productID)
        {
            var product = repository.Products
                .FirstOrDefault(m => m.ProductID == productID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null )
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}