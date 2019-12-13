using SportsMarket.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsMarket.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRespository repository;

        public NavController(IProductRespository repo)
        {
            repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p);
            return PartialView("FlexMenu", categories);
        }
    }
}