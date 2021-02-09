using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebApplication.Models;

namespace MyWebApplication.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var person = new Person();
            person.Name = "Alaxa";
            person.Salary = "100000";

            List<Person> personList = new List<Person>();
            personList.Add(new Person() { Name = "Denver", Salary = "20000" });
            personList.Add(new Person() { Name = "Tokyo", Salary = "40000" });
            return View(personList);

        }
    }
}