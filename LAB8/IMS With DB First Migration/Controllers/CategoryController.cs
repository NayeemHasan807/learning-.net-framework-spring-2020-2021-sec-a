using IMS_With_DB_First_Migration.Models;
using IMS_With_DB_First_Migration.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_With_DB_First_Migration.Controllers
{
    public class CategoryController : Controller
    {
        //private CFInventoryDbContext context = new CFInventoryDbContext(); 
        //// GET: Category
        //public ActionResult Index()
        //{
        //    return View(context.Categories.ToList());
        //}
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryRepository.Insert(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(categoryRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryRepository.Update(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(categoryRepository.Get(id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(categoryRepository.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}