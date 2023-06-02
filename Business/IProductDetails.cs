using Entities;
using ShopBridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    interface IProductDetails
    {

        List<Products> GetAllProducts(Category categories);

        int DeleteProductBasedOnID(long id);

        int AddToProductData(Products productItem);

        int EditToProductData(Products productItem);
    }
}
