using IMS_EF_DB_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_EF_DB_First.Controllers
{
    public class ProductController : Controller
    {
        InventoryDbContext context = new InventoryDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(context.Products.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["categories"] = context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData["categories"] = context.Categories.ToList();
            return View(context.Products.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(int id,Product product)
        {
            product.productid = id;
            var productToEdit = context.Products.Find(id);
            productToEdit.productname = product.productname;
            productToEdit.price= product.price;
            productToEdit.categoryid = product.categoryid;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(context.Products.Find(id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(context.Products.Find(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            context.Products.Remove(context.Products.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult TopTwo()
        {
            var list = context.Products.OrderByDescending(x => x.price).Take(2).ToList();
            return View(list);
        }
    }
}