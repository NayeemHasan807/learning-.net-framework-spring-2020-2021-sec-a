using Inventory_Management_System_With_ADO.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System_With_ADO.Net.Controllers
{
    public class ProductController : Controller
    {
        CategoryModel categoryModel = new CategoryModel();
        ProductModel productModel = new ProductModel();
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["categories"] = categoryModel.GetCategories();
            return View(productModel.GetProducts());
        }
        public ActionResult Create()
        {
            ViewData["categories"] = categoryModel.GetCategories();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productModel.Insert(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData["categories"] = categoryModel.GetCategories();
            return View(productModel.GetProduct(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            product.ProductId = id;
            productModel.Update(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewData["categories"] = categoryModel.GetCategories();
            return View(productModel.GetProduct(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            productModel.Delete(id);
            return RedirectToAction("Index");
        }
    }
}