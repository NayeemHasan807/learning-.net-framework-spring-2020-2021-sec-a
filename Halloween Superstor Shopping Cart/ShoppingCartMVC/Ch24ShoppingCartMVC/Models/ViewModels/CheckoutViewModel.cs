using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch24ShoppingCartMVC.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public List<ProductViewModel> Checkout { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }

    }
}