using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InventoryApp.Model;

namespace InventoryApp.DAL
{
    public class ProductGetway
    {
        //todo: save product and show all product from database 

        private string connectionString =
            "Server=DOLAR; Database=InventoryDB;Integrated Security=true;";


        public bool SaveProduct(Product product)
        {
            bool isSave = false;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //insert Qrey 
            string qrey = "INSERT INTO t_products (barcode,name,quantity,unitPrice,entryDate) VALUES ('" +
                          product.Barcode + "', '" + product.Name + "','" + product.Quantity + "','" + product.UnitPrice +
                          "','" + product.EntryDate + "')";

            SqlCommand command = new SqlCommand(qrey, connection);

            int numberOfRowsEffected = command.ExecuteNonQuery();

            if (numberOfRowsEffected > 0)
            {
                isSave = true;

            }

            return isSave;
        }

        public List<Product> GetProduct()
        {
            List<Product> productList = new List<Product>();

            SqlConnection connection = new SqlConnection(connectionString);

            string qrey = "SELECT * FROM t_products";

            SqlCommand command = new SqlCommand(qrey, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();

                    product.Barcode = reader["barcode"].ToString();
                    product.Name = reader["name"].ToString();
                    product.Quantity = int.Parse(reader["quantity"].ToString());
                    product.UnitPrice = int.Parse(reader["unitPrice"].ToString());
                    product.EntryDate = Convert.ToDateTime(reader["entryDate"]);
                    product.Total = product.Quantity*product.UnitPrice;
                    productList.Add(product);
                }
                reader.Close();
            }
            connection.Close();
            return productList;
        }

        public bool UpdateQuantity(Product newproduct, Product oldProduct)
        {
            bool isUpdate = false;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string qrey = "UPDATE t_products SET quantity='" + (newproduct.Quantity + oldProduct.Quantity) +
                          "' WHERE barcode='" + oldProduct.Barcode + "'";
            SqlCommand command = new SqlCommand(qrey, connection);
            int numberOfRowsEffected = command.ExecuteNonQuery();
            if (numberOfRowsEffected > 0)
            {
                isUpdate = true;
            }



            return isUpdate;

        }

        
        public List<Product> GetProductByDate(DateTime fromDate, DateTime toDate)
        {
            List<Product> productList = new List<Product>();
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string qrey = "SELECT * FROM t_products where entrydate BETWEEN '" + fromDate + "' AND  '" + toDate + "'";
            SqlCommand command = new SqlCommand(qrey, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();

                    product.Barcode = reader["barcode"].ToString();
                    product.Name = reader["name"].ToString();
                    product.Quantity = int.Parse(reader["quantity"].ToString());
                    product.UnitPrice = int.Parse(reader["unitPrice"].ToString());
                    product.EntryDate = Convert.ToDateTime(reader["entryDate"]);
                    product.Total = product.Quantity*product.UnitPrice;
                    productList.Add(product);
                }
                reader.Close();
            }
            connection.Close();
            return productList;
        }
    }
}
