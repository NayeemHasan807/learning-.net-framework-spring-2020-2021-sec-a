using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS_Code_First.Models
{
    //To configur our database column and tables we have two techniques
    //1.Data Annotations
    //2.Fluent API
    //[Table("Categories",Schema ="dbo")]
    public class Category
    {
        //[Key,MaxLength(10),MinLength(1)]//It will be not null and by default identity will be true
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//By this we can config identity
        public int CategoryId { get; set; }
        //[Required,StringLength(20)]//Not accepting any null
        public string CategoryName { get; set; }
        //[NotMapped]//wont go to db table
        //[ForeignKey("PropertyName")]//To add a foreign key
    }
}