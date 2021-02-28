using IMS_EF_DB_First.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS_EF_DB_First.Models
{
    public class ProductMetaData
    {
        public int productid { get; set; }

        [Required, MaxLength(15), Display(Name = "Product Name"),NameCheck(ErrorMessage ="Can't contain + inside the name")]
        public string productname { get; set; }

        [Required, Range(0, 10000)]
        public double price { get; set; }
        
        [Required]
        public int categoryid { get; set; }
    }
}