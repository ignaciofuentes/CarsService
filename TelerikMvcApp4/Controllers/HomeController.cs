using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TelerikMvcApp4.Controllers
{
    public class CarViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Sold { get; set; }

        public decimal Price { get; set; }
    }







    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new CarsDb();
            var x = db.Cars.ToList();
            return View();
        }
    }
}
