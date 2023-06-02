using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Repository;

namespace ShopBridge
{
    public class CategoriesController : ApiController
    {
        private Categories catories;
        private CategoryRepository catoriesRepository;

        [Route("api/Categories/GetAllCategories")]
        [HttpPost]
        public HttpResponseMessage GetAllCategories(Category categories)
        {
            InitializeConfiguration();

            List<Category> categoryCollection = catories.GetAllCategories();

            if (categoryCollection.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, categoryCollection);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "No Data Found");
            }
        }

        [Route("api/Categories/AddToCategories")]
        [HttpPost]
        public HttpResponseMessage AddToCategories(Category categoryItem)
        {
            InitializeConfiguration();

            int rowAffected = catories.InsertDataIntoCategories(categoryItem);
            if (rowAffected > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data inserted successfully!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Error occured");
            }
        }

        private void InitializeConfiguration() {


            catories = new Categories(catoriesRepository, catories);

        }

    }
}