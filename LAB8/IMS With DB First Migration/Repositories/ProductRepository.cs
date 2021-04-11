using IMS_With_DB_First_Migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS_With_DB_First_Migration.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public List<Product> GetTopProducts(int top)
        {
            return this.context.Products.OrderByDescending(x => x.Price).Take(top).ToList();
        }
    }
}