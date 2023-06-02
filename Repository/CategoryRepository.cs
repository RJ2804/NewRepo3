
namespace Repository
{
    using System;
    using ShopBridge;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connectionString;
        private string getCategories = "GetCategories";
        private string insertIntoCategories = "InsertIntoCategories";

        public CategoryRepository() {
            connectionString = ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString;
        }

        public List<Category> GetAllCategoriesCollection()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(getCategories, sqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Category> categorCollection = new List<Category>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Category categoryItem = new Category
                    {
                        Id = Convert.ToInt64(dt.Rows[i]["Id"]),
                        CategoryName = Convert.ToString(dt.Rows[i]["CategoryName"]),
                        CategoryCode = Convert.ToString(dt.Rows[i]["CategoryCode"]),
                        CategoryDescription = Convert.ToString(dt.Rows[i]["CategoryDescription"])
                    };
                    categorCollection.Add(categoryItem);
                }
            }
            return categorCollection;
        }

        public int InsertIntoCategories(Category categoryItem) 
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(insertIntoCategories, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@categoryName", categoryItem.CategoryName);
            cmd.Parameters.AddWithValue("@categoryCode", categoryItem.CategoryCode);
            cmd.Parameters.AddWithValue("@categoryDescription", categoryItem.CategoryDescription);


            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return i;
        }

    }
}
