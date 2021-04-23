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
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        ProductRepository prorepo = new ProductRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            List<Product> products = prorepo.GetAll();
            return Ok(products);
        }
        [Route("{id}", Name = "GetById")]
        public IHttpActionResult Get(int id)
        {
            Product product = prorepo.Get(id);
            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(product);
        }

        [Route("")]
        public IHttpActionResult Post(Product product)
        {
            prorepo.Insert(product);
            string url = Url.Link("GetById", new { id = product.categoryid });
            return Created(url, product);
        }
        [Route("{id}"), HttpPut]
        public IHttpActionResult Edit([FromBody] Product product, [FromUri] int id)
        {
            product.productid = id;
            prorepo.Update(product);
            return Ok(product);
        }

        [Route("{id}"), HttpDelete]
        public IHttpActionResult Remove([FromUri] int id)
        {

            prorepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
