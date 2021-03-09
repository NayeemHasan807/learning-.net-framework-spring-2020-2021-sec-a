using Ch24ShoppingCartMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch24ShoppingCartMVC.Models
{
    public class CheckoutModel
    {
        
        public CheckoutViewModel GetCheckout()
        {
            CheckoutViewModel checkout = new CheckoutViewModel();
            CartModel cart = new CartModel();
            CartViewModel selectedProduct = cart.GetCart();
            checkout.Checkout = selectedProduct.Cart;
            foreach (var item in checkout.Checkout)
            {
                var pfori = item.Quantity * item.UnitPrice;
                checkout.TotalPrice = checkout.TotalPrice + pfori;
            }
            checkout.TotalPriceWithTax = ((checkout.TotalPrice * 10) / 100) + checkout.TotalPrice;
            return checkout;
        }

        public void AddCheckout(PaymentViewModel payment)
        {
            HttpContext.Current.Session["Payment"] = payment;
        }
    }
}