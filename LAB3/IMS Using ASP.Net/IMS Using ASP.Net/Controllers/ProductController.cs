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
    }
}