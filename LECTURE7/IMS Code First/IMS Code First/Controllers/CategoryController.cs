using IMS_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_Code_First.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CFInventoryDbContext context = new CFInventoryDbContext();
            var list = context.Categories.ToList();
            return View();
        }
    }
}