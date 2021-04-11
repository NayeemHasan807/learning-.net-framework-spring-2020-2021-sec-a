using System;
using System.Data.Entity;
using System.Linq;

namespace IMS_Code_First.Models
{
    public class CFInventoryDbContext : DbContext
    {   /*
         * 1.No Parameter
        public CFInventoryDbContext():base()
        { }*/
        /*
         * 2.Database Name
        public CFInventoryDbContext():base("CFInventoryDb")
        { }*/
        /*
         * 3.Using Connection String Name*/
        public CFInventoryDbContext():base("name=CFInventoryDbContext")
        {
            //Database Initialization Property/Strategy
            /*
             * 1
            //This means every time when i will run the application it will create the DB if the DB is not created.
            //This is the by default settings. If the database is created and after that we change something in model class then it will give error.
            new CreateDatabaseIfNotExists<CFInventoryDbContext>();*/
            /*
             * 2
            //This means every time when i will run the application it will drop the previous DB if the model class is chenged. Then it will create new DB
            new DropCreateDatabaseIfModelChanges<CFInventoryDbContext>();*/
            /*
             * 3
            //This means every time when i will run the application it will drop the previous DB either the model class is chenged or not. Then it will create new DB
            new DropCreateDatabaseAlways<CFInventoryDbContext>();*/
            /*
             * 4
            //This is an advanced technologies and we wont cover it in this course
            Custome*/

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CFInventoryDbContext>());
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
