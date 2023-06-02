using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopBridge;

namespace Repository
{
    interface IProductRepository
    {

        List<Products> GetAllProductCollection(Category categories);

        int DeleteProductIdWise(long id);

        int InsertIntoProducts(Products productItem);

        int EditIntoProducts(Products productItem);
    }
}
