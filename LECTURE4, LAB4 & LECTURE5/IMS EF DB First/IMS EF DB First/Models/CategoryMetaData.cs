using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS_EF_DB_First.Models
{
    public class CategoryMetaData
    {
        public int categoryid { get; set; }

        [Required, MaxLength(10), Display(Name = "Category Name")]
        public string categoryname { get; set; }
        
    }
}