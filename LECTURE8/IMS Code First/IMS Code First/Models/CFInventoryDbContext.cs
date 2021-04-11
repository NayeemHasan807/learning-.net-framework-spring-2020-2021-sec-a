using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
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
        //To implement Fluent API we will override this method
        //Before DB create this method will be called and follow this method logics to create DB
        //Fluent API uses pipeline concept
        //Two types of logic one is for table and other is for property
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            //Entity Configuration
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(k => k.CategoryId);*/
            
            //Pipeline Technique
            //Entity Configuration
            modelBuilder.Entity<Category>().ToTable("Categories")
                                           .HasKey<int>(k => k.CategoryId);
            //Property Configuration
            modelBuilder.Entity<Category>().Property(x => x.CategoryId).HasColumnName("CategoryId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.CategoryName).IsRequired()
                                                                         .HasColumnName("CategoryName")
                                                                         .HasColumnType("varchar")
                                                                         .HasMaxLength(20);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
