using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPIExample.Controllers
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
    public class PersonsController : ApiController
    {
        static List<Person> people = new List<Person>()
            {
                new Person(){Id=1,Name="Nayeem",Salary=30000},
                new Person(){Id=2,Name="Hasan",Salary=20000},
                new Person(){Id=3,Name="Moon",Salary=40000}
            };
        public IHttpActionResult Get()
        {
            return Ok(people);
        }
        public IHttpActionResult Post(Person person)
        {
            people.Add(person);
            return Created("http://localhost:54921/api/persons", people);
        }
        public IHttpActionResult Get(int id)
        {
            if (people.Find(x => x.Id == id) != null)
            {
                return Ok(people.Find(x => x.Id == id));
            }
            else
                return StatusCode(HttpStatusCode.NoContent);

        }
        public IHttpActionResult Put(int id, Person person)
        {
            var personToUpdate = people.Find(i => i.Id == id);
            personToUpdate.Name = person.Name;
            personToUpdate.Salary = person.Salary;
            return Ok(personToUpdate);
        }
        public IHttpActionResult Delete(int id)
        {
            people.Remove(people.Find(i => i.Id == id));
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
