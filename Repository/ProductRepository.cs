

namespace Repository
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using Entities;
    using ShopBridge;

    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString;
        private string getAllProducts = "GetAllProducts";
        private string deleteProduct = "DeleteProduct";
        private string insertIntoProducts = "InsertIntoProducts";
        private string editIntoProducts = "EditIntoProducts";

        public ProductRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString;
        }

        public List<Products> GetAllProductCollection(Category categories)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(getAllProducts, sqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Products> productCollection = new List<Products>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Products productItem = new Products
                    {
                        ProductId = Convert.ToInt64(dt.Rows[i]["ProductId"]),
                        ProductName = Convert.ToString(dt.Rows[i]["ProductName"]),
                        ProductDescription = Convert.ToString(dt.Rows[i]["ProductDescription"]),
                        Price = Convert.ToDecimal(dt.Rows[i]["Price"]),
                        ProductImage = Convert.ToString(dt.Rows[i]["ProductImage"]),
                        CategoryId = Convert.ToInt64(dt.Rows[i]["CategoryId"])
                    };

                    if (productItem.CategoryId == categories.Id)
                    {
                        productCollection.Add(productItem);
                    }
                }
            }
            return productCollection;
        }

        public int DeleteProductIdWise(long id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(deleteProduct, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return i;
        }


        public int InsertIntoProducts(Products productItem)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(insertIntoProducts, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@productName", productItem.ProductName);
            cmd.Parameters.AddWithValue("@productDescription", productItem.ProductDescription);
            cmd.Parameters.AddWithValue("@price", productItem.Price);
            cmd.Parameters.AddWithValue("@productImage", productItem.ProductImage);
            cmd.Parameters.AddWithValue("@categoryId", productItem.CategoryId);


            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return i;
        }

        public int EditIntoProducts(Products productItem)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(editIntoProducts, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@productId", productItem.ProductId);
            cmd.Parameters.AddWithValue("@productName", productItem.ProductName);
            cmd.Parameters.AddWithValue("@productDescription", productItem.ProductDescription);
            cmd.Parameters.AddWithValue("@price", productItem.Price);
          //  cmd.Parameters.AddWithValue("@productImage", productItem.ProductImage);
           // cmd.Parameters.AddWithValue("@categoryId", productItem.CategoryId);


            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return i;
        }
    }
}
