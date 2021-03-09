using Ch24ShoppingCartMVC.Models;
using Ch24ShoppingCartMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckoutController : Controller
    {
        CheckoutModel checkout = new CheckoutModel();
        public ActionResult Index()
        {
            TempData["Checkout"]=checkout.GetCheckout();
            return View();
        }
        [HttpPost]
        public ActionResult Index(PaymentViewModel payment)
        {
            if(ModelState.IsValid)
            {
                checkout.AddCheckout(payment);
                TempData["Checkout"] = null;
                CartModel cart = new CartModel();
                cart.ClearCart();
                return View("Conformation");
            }
            TempData["Checkout"] = checkout.GetCheckout();
            return View();
        }

    }
}
