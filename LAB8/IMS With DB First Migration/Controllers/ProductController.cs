using IMS_With_DB_First_Migration.Models;
using IMS_With_DB_First_Migration.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_With_DB_First_Migration.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        [HttpGet]
        public ActionResult Index()
        {
            return View(productRepository.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["categories"] = categoryRepository.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productRepository.Insert(product);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData["categories"] = categoryRepository.GetAll();
            return View(productRepository.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            productRepository.Update(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(productRepository.Get(id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(productRepository.Get(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            productRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}