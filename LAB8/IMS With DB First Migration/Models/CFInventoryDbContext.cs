using IMS_With_DB_First_Migration.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMS_With_DB_First_Migration.Models
{
    public class CFInventoryDbContext : DbContext
    {
        public CFInventoryDbContext():base("name=CFInventoryDbContext")
        {
            //This initializer is set when we use migration. This initializer takes context class and configuration class to generate the db
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CFInventoryDbContext,Configuration>());
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}