using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.DTO;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Service()
        {
            /*** inicio, estos datos por lo general vienen de una DB o de un API ****/
            ViewBag.Message = "Your service page.";
            User user = new User();
            user.Name = "Elias";
            user.Age = 15;

            Product product = new Product();
            product.ProductName = "Phone";
            product.Price = 200;

            DashboardDto dto = new DashboardDto();
            dto.UserModel = user;
            dto.ProductModel = product;

            return View(dto);
        }
    }
}