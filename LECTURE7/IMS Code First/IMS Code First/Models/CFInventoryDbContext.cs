using System;
using System.Data.Entity;
using System.Linq;

namespace IMS_Code_First.Models
{
    public class CFInventoryDbContext : DbContext
    {   /*1.No Parameter
        public CFInventoryDbContext():base()
        { }*/
        /*2.Database Name
        public CFInventoryDbContext():base("CFInventoryDb")
        { }*/
        //3.Using Connection String Name
        public CFInventoryDbContext():base("name=CFInventoryDbContext")
        { }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
