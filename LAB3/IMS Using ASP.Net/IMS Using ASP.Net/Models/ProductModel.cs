using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory_Management_System_With_ADO.Net.Models
{
    public class ProductModel
    {
        DataAccess dataAccess;
        public ProductModel()
        {
            dataAccess = new DataAccess();
        }

        public List<Product> GetProducts()
        {
            string sql = "SELECT * FROM Products";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Product> products = new List<Product>();
            while(reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader["ProductId"];
                product.ProductName = reader["Productname"].ToString();
                product.CategoryId = (int)reader["CategoryId"];
                products.Add(product);
            }
            return products;
        }
    }
}