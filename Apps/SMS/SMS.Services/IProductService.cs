using SMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Services
{
    public interface IProductService
    {
        void CreateProduct(string name, decimal price);

        IEnumerable<Product> GetAllProducts();
    }
}
