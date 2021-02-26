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
                product.Price = Convert.ToSingle(reader["Price"]);
                product.CategoryId = (int)reader["CategoryId"];
                products.Add(product);
            }
            return products;
        }

        public Product GetProduct(int id)
        {
            string sql = "SELECT * FROM Products Where productid=" + id;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Product product = new Product();
            product.ProductId = (int)reader["ProductId"];
            product.ProductName = reader["ProductName"].ToString();
            product.Price = Convert.ToSingle(reader["Price"]);
            product.CategoryId = (int)reader["CategoryId"];

            return product;
        }

        public int Insert(Product product)
        {
            string sql = "INSERT INTO Products(ProductName,Price,CategoryId) VALUES('" + product.ProductName + "' , '"+ product.Price + "' , '" + product.CategoryId + "')";
            int result = dataAccess.ExecuteQuery(sql);
            return result;
        }

        public int Update(Product product)
        {
            string sql = "UPDATE Products SET ProductName='" + product.ProductName + "' , Price="+ product.Price +" , CategoryId="+ product.CategoryId +" WHERE ProductId=" + product.ProductId;
            int result = dataAccess.ExecuteQuery(sql);
            return result;
        }

        public int Delete(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductId=" + id;
            int result = dataAccess.ExecuteQuery(sql);
            return result;
        }
    }
}