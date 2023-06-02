using ShopBridge;
using System.Collections.Generic;

namespace Business
{
    interface ICategories
    {

        List<Category> GetAllCategories();

       int InsertDataIntoCategories(Category categoryItem);
    }
}
