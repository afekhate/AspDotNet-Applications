using SportsMarket.Domain.Abstract;
using SportsMarket.Domain.Entities;
using SportsMarket.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SportsMarket.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRespository repository;
        private IOrderProcessor orderProcessor;
        
        public CartController(IProductRespository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

    
        // GET:
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl )
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });   
        }

       

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if(product !=null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {

                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }

            
        }

       
    }
}