using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ch24ShoppingCartMVC.Models.ViewModels
{
    public class PaymentViewModel
    {
        [Required]
        public string PaymentMethod { get; set; }
        [Required,MinLength(8)]
        public string Address { get; set; }
        [Required,MinLength(4)]
        public string City { get; set; }
        [Required,MinLength(3)] 
        public string State { get; set; }
        [Required(ErrorMessage = "Zip code is required"),MinLength(3, ErrorMessage = "Zip code must need to be 3 digit number"),MaxLength(3, ErrorMessage = "Zip code must need to be 3 digit number"), Range(001,999, ErrorMessage = "Zip code must need to be 3 digit number")]
        public String ZipCode { get; set; }

    }
}