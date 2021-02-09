using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            Session["FName"] = "Nayeem";
            ViewData["MName"] = "Hasan";
            ViewBag.LName = "Moon";
            TempData["FullName"] = "Nayeem Hasan Moon";
            //return RedirectToAction("Show");
            //return RedirectToAction("Show", new {id=11});
            //return View();
            return RedirectToAction("Index", "Person");
        }
        public ActionResult Show(int? id)
        {
            return View("Index");
            //return Content("done:"+ id);
        }
    }
}