using IMS_Using_Api_And_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS_Using_Api_And_Repository.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public List<Product> GetTopProducts(int top)
        {
            return this.context.Products.OrderByDescending(x => x.price).Take(top).ToList();
        }
    }
}