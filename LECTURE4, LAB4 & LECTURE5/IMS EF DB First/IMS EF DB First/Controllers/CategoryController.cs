using IMS_EF_DB_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_EF_DB_First.Controllers
{
    public class CategoryController : Controller
    {
        InventoryDbContext context = new InventoryDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(context.Categories.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(context.Categories.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            if(ModelState.IsValid)
            {
                category.categoryid = id;
                var categoryToEdit = context.Categories.Find(id);
                categoryToEdit.categoryname = category.categoryname;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(context.Categories.Find(id));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(context.Categories.Find(id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(context.Categories.Find(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}