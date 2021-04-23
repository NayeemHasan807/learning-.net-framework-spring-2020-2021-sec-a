using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS_Using_Api_And_Repository.Models
{
    public class CategoryMetaData
    {
        public int categoryid { get; set; }

        [Required, MaxLength(10), Display(Name = "Category Name")]
        public string categoryname { get; set; }
        
    }
}