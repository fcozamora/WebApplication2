using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.DAO;
using WebApplication2.Models.DTO;

namespace WebApplication2.Controllers
{
    public class CarController : Controller
    {
        private CarDao carDao = new CarDao();
        // GET: Car
        public ActionResult Index()
        {
            return View(carDao.ReadCars());
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            return View(carDao.ReadCarById(id));
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(CarDto car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string res = carDao.CreateCar(car);
                    if (res == "Success") return RedirectToAction("Index");
                    else ModelState.AddModelError("", "Failed to create car");

                }

                return View(car);
            }
            catch
            {
                return View(car);
            }
        }

    }
}
