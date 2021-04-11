using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS_With_DB_First_Migration.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }//To give a navigation property to category class

    }
}