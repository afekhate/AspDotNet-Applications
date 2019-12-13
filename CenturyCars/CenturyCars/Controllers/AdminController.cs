using CenturyCars.Models;
using CenturyCars.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CenturyCars.Domain.Entities;
using System.IO;

namespace CenturyCars.Controllers
{
    public class AdminController : Controller
    {
        public ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin
        [Authorize(Users = "admin@asp.net")]
        public ActionResult Index()
        {
            var cars = _context.Car.Include(m => m.Manufacturer).ToList();
            return View(cars);
        }

        public ActionResult List()
        {
            var car = _context.Car.Include(m => m.Manufacturer).ToList();
            return View(car);
        }

        public ActionResult Add()
        {
            var manufacturer = _context.Manufacturer.ToList();
            var viewmodel = new CarsFormViewModel()
            {
                Manufacturer = manufacturer,
                Car = new Car()
            };
            return View("Add", viewmodel);
        }

        [HttpPost]
        public ActionResult Add(Car car)
        {

            if (ModelState.IsValid)
            {

                HttpPostedFileBase file = Request.Files[0];

                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(file.FileName).ToLower() == ".png"
                                || Path.GetExtension(file.FileName).ToLower() == ".gif"
                                || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                        {
                            string filename = Path.GetFileName(file.FileName);
                            car.ImagePath = "~/Image/" + filename;
                            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                            file.SaveAs(filename);
                        }
                    }
                }
                if (car.CarID == 0)
                    _context.Car.Add(car);
                else
                {
                    var carInDb = _context.Car.Single(m => m.CarID == car.CarID);

                    carInDb.Description = car.Description;
                    carInDb.ImagePath = car.ImagePath;
                    carInDb.ManufacturerID = car.ManufacturerID;
                    carInDb.Name = car.Name;
                    carInDb.Price = car.Price;
                    carInDb.Rating = car.Rating;
                }

                _context.SaveChanges();

            }

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var car = _context.Car.SingleOrDefault(m => m.CarID == id);
            var manufacturer = _context.Manufacturer.ToList();

            var viewmodel = new CarsFormViewModel
            {
                Car = car,
                Manufacturer = manufacturer
            };
            return View("Add", viewmodel);
        }

        public ActionResult Details(int id)
        {
            var car = _context.Car.Include(m => m.Manufacturer).SingleOrDefault(m => m.CarID == id);
            return View(car);
        }

        public ActionResult Delete(int id)
        {
            var car = _context.Car.Find(id);

            if (car != null)
            {
                _context.Car.Remove(car);
                _context.SaveChanges();

                return View(car);
            }
            return RedirectToAction("Index", "Admin");
        }


        
    }
}