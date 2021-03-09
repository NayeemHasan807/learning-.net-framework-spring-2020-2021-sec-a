using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Models{
    public class CartModel
    {
        //Data Access methods 
        //List<ProductViewModel> cart; //if i put this out from method i can directly use this to add new things.[1]
        private List<ProductViewModel> GetCartFromDataStore()
        {
            List<ProductViewModel> cart;
            object objCart = HttpContext.Current.Session["cart"];
            //Convert objCart to List<ProductViewModel>
            cart = objCart as List<ProductViewModel>;
            if (cart == null)
            {   //Create the object cart
                cart = new List<ProductViewModel>();
                //Assign cart to the Session object cart
                HttpContext.Current.Session["cart"] = cart;
            }
            return cart;
        }
        private ProductViewModel GetSelectedProduct(string id)
        {   //Create an OrderModel object called order
            OrderModel order = new OrderModel();
            //Call the method GetSelectedProduct of the class OrderModel. Return the object returned by the call.
            return order.GetSelectedProduct(id);
        }
        public CartViewModel GetCart(string id = "")
        {
            CartViewModel model = new CartViewModel();
            //Call the method GetCartFromDataStore
            model.Cart = GetCartFromDataStore();
            if (!string.IsNullOrEmpty(id))
                //Called the method GetSelectedProduct with parameter id and assign the return object to the AddedProduct
                model.AddedProduct = GetSelectedProduct(id); 
            return model;
        }
        private void AddItemToDataStore(CartViewModel model)
        {   //Add the AddedProduct to the cart
            //cart.Add(model.AddedProduct); //[1]
            List<ProductViewModel> cart = HttpContext.Current.Session["cart"] as List<ProductViewModel>;
            cart.Add(model.AddedProduct);
            HttpContext.Current.Session["cart"] = cart;
        }
        public void AddToCart(CartViewModel model)
        {
            if (model.AddedProduct.ProductID != null)
            {
                //Get the product id of the added product
                var pID = model.AddedProduct.ProductID;
                //Find the product in the cart that matches the id using lambda expression.
                //var inCart = cart.Where(x => x.ProductID == pID).FirstOrDefault();//[1]
                List<ProductViewModel> cart = HttpContext.Current.Session["cart"] as List<ProductViewModel>;
                var inCart = cart.Where(x => x.ProductID == pID).FirstOrDefault();
                if (inCart == null)
                    //Call the method AddItemToDataStore
                    AddItemToDataStore(model); 
                else
                //Increase the Quantity by the quantity of the added product
                {
                    //cart.Where(x => x.ProductID == pID).FirstOrDefault().Quantity = model.AddedProduct.Quantity;//[1]
                    cart.Where(x => x.ProductID == pID).FirstOrDefault().Quantity = cart.Where(x => x.ProductID == pID).FirstOrDefault().Quantity + model.AddedProduct.Quantity;
                    HttpContext.Current.Session["cart"] = cart;
                }
            }
        }
        public void ClearCart()
        {
            HttpContext.Current.Session["cart"] = null;
        }

        public void RemoveFromCart(string id)
        {
            List<ProductViewModel> cart = HttpContext.Current.Session["cart"] as List<ProductViewModel>;
            var inCart = cart.Where(x => x.ProductID == id).FirstOrDefault();
            cart.Remove(inCart);
            HttpContext.Current.Session["cart"] = cart;
        }
    }    
}