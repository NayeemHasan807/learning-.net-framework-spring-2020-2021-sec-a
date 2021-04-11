using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS_With_DB_First_Migration.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; } //This automatically take categoryid as a foreign key
        public virtual Category Category { get; set; } //Enforceing that this catagory is the foreign key table
                                                       //Virtual i given to make it a lazy loading
    }
}