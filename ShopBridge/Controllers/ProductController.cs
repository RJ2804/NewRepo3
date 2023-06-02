
namespace ShopBridge
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Business;
    using Entities;
    using Repository;

    public class ProductController : ApiController
    {
        private ProductDetails productsDetails;
        private ProductRepository productsRepository;

        [Route("api/Product/getAllProductDetails")]
        [HttpPost]
        public HttpResponseMessage GetAllProductDetails(Category categories)
        {
            InitializeConfiguration();

            
            
            List<Products> productCollection = productsDetails.GetAllProducts(categories);

            if (productCollection.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, productCollection);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "No Data Found");
            }
        }

        [Route("api/Product/DeleteProductIdWise")]
        [HttpPost]
        public HttpResponseMessage DeleteProductIdWise(Products productDetails)
        {
            InitializeConfiguration();

            int rowAffected = productsDetails.DeleteProductBasedOnID(productDetails.ProductId);
            if (rowAffected > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data deleted successfully!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Error occured");
            }
        }

        [Route("api/Product/AddToProductCollection")]
        [HttpPost]
        public HttpResponseMessage AddToProductCollection(Products productItem)
        {
            InitializeConfiguration();

            int rowAffected = productsDetails.AddToProductData(productItem);
            if (rowAffected > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data inserted successfully!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Error occured");
            }
        }

        [Route("api/Product/EditToProductDetails")]
        [HttpPost]
        public HttpResponseMessage EditToProductDetails(Products productItem)
        {
            InitializeConfiguration();

            int rowAffected = productsDetails.EditToProductData(productItem);
            if (rowAffected > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data updated successfully!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Error occured");
            }
        }

        private void InitializeConfiguration()
        {


            productsDetails = new ProductDetails();

        }

    }
}