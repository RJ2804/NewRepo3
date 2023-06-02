using System;
using System.Collections.Generic;
using Repository;
using ShopBridge;

namespace Business
{
    public class Categories : ICategories
    {
        CategoryRepository categoriesRepo = new CategoryRepository();


        public Categories(CategoryRepository catRepo ,Categories catories) : base() {

            catRepo = categoriesRepo;

        }

        public List<Category> GetAllCategories() {

            try
            {
                List<Category> categoriesData = categoriesRepo.GetAllCategoriesCollection();
                return categoriesData;
            }
            catch (Exception ex) 
            {
                throw ex;               
            }
        }


        public int InsertDataIntoCategories(Category categoryItem) {

            try
            {
                int affectedRows = categoriesRepo.InsertIntoCategories(categoryItem);
                return affectedRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
