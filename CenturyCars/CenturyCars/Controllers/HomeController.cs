using CenturyCars.Domain.Entities;
using CenturyCars.Models;
using CenturyCars.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CenturyCars.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       

        public ActionResult Index()
        {
            var cars = _context.Car.Include(m => m.Manufacturer).Where(m => m.Rating == 5);
            return View(cars.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult List()
        {
            var car = _context.Car.Include(m => m.Manufacturer).ToList();
            return View(car);
        }


        [Authorize]
        public ActionResult Details(int id)
        {
            var car = _context.Car.Include(m => m.Manufacturer).SingleOrDefault(m => m.CarID == id);
            return View(car);
        }

        [HttpGet]
        public ActionResult Update()
        {
            return PartialView("Update");
        }

        [HttpPost]
        public ActionResult Update(Message message)
        {
            if (message.MessageID == 0)

                _context.Message.Add(message);
            TempData["message"] = "Your Message has been Sent";
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Order()
        {
            return View("Order");
        }

        [HttpPost]
        public ActionResult Order(Order order)
        {

            if (order.OrderId == 0)
            {
                _context.Order.Add(order);
                _context.SaveChanges();
                TempData["message"] = "We have Received your Order";
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CarSearch(string q)
        {
            var car = GetCars(q);
            return PartialView(car);
        }
        private List<Car> GetCars(string searchString)
        {
            return _context.Car.Include(m => m.Manufacturer)
            .Where(a => a.Manufacturer.Name.Contains(searchString))
            .ToList();
        }

    }
}