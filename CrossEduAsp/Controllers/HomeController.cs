using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrossEduAsp.Models;

namespace CrossEduAsp.Controllers
{
    public class HomeController : Controller
    {
		ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
			var gameentities = db.GameEntities.OrderByDescending(x=>x.CounterViews);
			return View(gameentities.ToList());
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
    }
}