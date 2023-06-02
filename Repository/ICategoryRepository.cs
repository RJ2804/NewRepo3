using ShopBridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface ICategoryRepository
    {

        List<Category> GetAllCategoriesCollection();

        int InsertIntoCategories(Category categoryItem);
    }
}
