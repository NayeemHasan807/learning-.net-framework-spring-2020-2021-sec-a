using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers 
{
    public class CartController : Controller
    {
        private CartModel cart = new CartModel();

        [HttpGet]
        public RedirectToRouteResult Index()
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public ViewResult List()
        {
            CartViewModel model = (CartViewModel)TempData["cart"];
            //if the model is null, then call the method GetCart
            if(model==null)
            {
                model = cart.GetCart();
            }
            //Passing model to View
            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult List(OrderViewModel order)
        {
            if(ModelState.IsValid)
            {
                CartViewModel model = cart.GetCart(order.SelectedProduct.ProductID);
                //Assign the quantity of the selected product to the quantity of the added product
                if(model.AddedProduct.Quantity >= order.SelectedProduct.Quantity)
                {
                    model.AddedProduct.Quantity = order.SelectedProduct.Quantity;
                    //Call the method AddtoCart
                    cart.AddToCart(model);
                    //Assign model to the TempData
                    TempData["cart"] = model; //confussion //how this added last product to cart
                    return RedirectToAction("List", "Cart");
                }
                TempData["Error"] = "Can't be empty and Quentity must be in between 1 to available quantities";
                return RedirectToAction("Index", "Order", new { id = order.SelectedProduct.ProductID });

            }
            TempData["Error"] = "Can't be empty and Quentity must be in between 1 to available quantities";
            return RedirectToAction("Index", "Order", new { id = order.SelectedProduct.ProductID });
            
        }

        [HttpGet]
        public ActionResult EorD()
        {
            CartViewModel model = cart.GetCart();
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            cart.RemoveFromCart(id);
            return RedirectToAction("List", "Cart");
        }
    }
}
