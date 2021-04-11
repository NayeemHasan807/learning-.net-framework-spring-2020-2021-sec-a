namespace IMS_With_DB_First_Migration.Migrations
{
    using IMS_With_DB_First_Migration.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //Two types of migration available
    /*
        1.Automatic Migration
        To enable the automatic migration we have to go to
        ->tools
        ->Nuget package manager
        ->Package manager console
        ->Give command "enable-migrations -enableautomaticmigration:$true"
        ->A new folder will create named Migration with a file named Configuration.cs
        ->Use seed method in configuration class to define initial data for database
        ->Set the initializer in context class
        ->Run the application and the database will be generated
        ->If we update the model class and run the application again then automatic migration will update the database automaticall
        ->In the database table migration history we can see the logs of our migration
        ->a drowback is we cant rebart back to previous migration
        ->If we remove something from model class we have to set the AutomaticMigrationDataLossAllowed to true
        End: Automatic migration deal with everything by itself and we cant controll or move back to previous by ourself. So, Its good to use manual migration.
    */
    /*
        2.Code First Migration/Menual Migration
        To enable the automatic migration we have to go to
        ->tools
        ->Nuget package manager
        ->Package manager console
        ->Give command "enable-migrations" and this will enable the migration
        ->A new folder will create named Migration with a file named Configuration.cs
        ->Use seed method in configuration class to define initial data for database
        ->Set the initializer in context class
        ->If we run the application now it will create the database but wont create any migration state which we can keep track of
        ->Its a good practice every time we make change to our model class we create a migration state class for that changes. So that we can keep track of db
        ->To make a migration state give command "add-migration Migration_Name"
        ->In a migration class there are two methods one is up and other is down
        ->Up is to create that db
        ->down is when i will move to another migration it will drop the current database
        ->To create the database with the migration we have to give command "update-database"
        ->give command "update-database -verbose" to see which migration is exicuated
        ->If we change model class we will create another migration and update the database
        ->Its good to updat migration alongside model class to prevent error
        ->If we want to go back to any previous migration we will use the command "update-database -targetmigration:MigrationName"
     */
    //This class can not be inharited
    internal sealed class Configuration : DbMigrationsConfiguration<IMS_With_DB_First_Migration.Models.CFInventoryDbContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = true; //We have enabled automatic migration
            //AutomaticMigrationDataLossAllowed = true //We have to allow this in order to remove something from model class in automated migration
            AutomaticMigrationsEnabled = false; //As we are doing manual migration
        }
        //This seed means when we will create the database what are the default values that we will put in db
        protected override void Seed(IMS_With_DB_First_Migration.Models.CFInventoryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            List<Category> categories = new List<Category>()
            {
                new Category{ CategoryName="Food"},
                new Category{ CategoryName="Cloths"}
            };
            //Checks if it has any eliments or not
            if(!context.Categories.Any()) 
            {
                foreach (var item in categories)
                {
                    context.Categories.Add(item);
                    context.SaveChanges();
                }
            }
        }
    }
}
