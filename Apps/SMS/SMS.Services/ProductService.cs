using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Data;
using SMS.Models;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly SMSContext db;

        public ProductService(SMSContext db)
        {
            this.db = db;
        }

        public void CreateProduct(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
            };


            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.db.Products.ToList();
        }
    }
}
