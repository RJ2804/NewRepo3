using Entities;
using Repository;
using ShopBridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductDetails : IProductDetails
    {

        ProductRepository productRepo = new ProductRepository();
        public List<Products> GetAllProducts(Category categories)
        {

            try
            {
                List<Products> productDetailsData = productRepo.GetAllProductCollection(categories);
                return productDetailsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       public int DeleteProductBasedOnID(long id)
        {

            try
            {
                int affectedRows = productRepo.DeleteProductIdWise(id);
                return affectedRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
}

       public int AddToProductData(Products productItem) {

            try
            {
                int affectedRows = productRepo.InsertIntoProducts(productItem);
                return affectedRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EditToProductData(Products productItem)
        {

            try
            {
                int affectedRows = productRepo.EditIntoProducts(productItem);
                return affectedRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
