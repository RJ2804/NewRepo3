using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge
{
    public class CategoriesController : ApiController
    {

        [Route("api/Categories/GetAllCategories")]
        //[ApiController]
        [HttpPost]
        public HttpResponseMessage GetAllCategories(Category categories)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter("GetCategories", sqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Category> list = new List<Category>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Category categoryItem = new Category
                    {
                        Id = Convert.ToInt64(dt.Rows[i]["Id"]),
                        CategoryName = Convert.ToString( dt.Rows[i]["CategoryName"]),
                        CategoryCode = Convert.ToString(dt.Rows[i]["CategoryCode"]),
                        CategoryDescription = Convert.ToString(dt.Rows[i]["CategoryDescription"])
                    };
                    list.Add(categoryItem);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/Categories/AddToCategories")]
        [HttpPost]
        public HttpResponseMessage AddToCategories(Category categoryItem)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString);

            SqlCommand cmd = new SqlCommand("InsertIntoCategories", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@categoryName", categoryItem.CategoryName);
            cmd.Parameters.AddWithValue("@categoryCode", categoryItem.CategoryCode);
            cmd.Parameters.AddWithValue("@categoryDescription", categoryItem.CategoryDescription);
    

            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (i > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data inserted successfully!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Error occured");
            }
        }

    }
}