using IMS_Using_Api_And_Repository.Models;
using IMS_Using_Api_And_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMS_Using_Api_And_Repository.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        CategoryRepository catrepo = new CategoryRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            List<Category> categories = catrepo.GetAll();
            return Ok(categories);
        }
        [Route("{id}",Name ="GetById")]
        public IHttpActionResult Get(int id)
        {
            Category category = catrepo.Get(id);
            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(category);
        }

        [Route("")]
        public IHttpActionResult Post(Category category)
        {
            catrepo.Insert(category);
            string url = Url.Link("GetById",new { id=category.categoryid});
            return Created(url,category);
        }
        [Route("{id}"),HttpPut]
        public IHttpActionResult Edit([FromBody]Category category,[FromUri]int id)
        {
            category.categoryid = id;
            catrepo.Update(category);
            return Ok(category);
        }

        [Route("{id}"), HttpDelete]
        public IHttpActionResult Remove([FromUri] int id)
        {

            catrepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
