using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly SMSContext db;

        public CartService(SMSContext db)
        {
            this.db = db;
        }

        public void AddToCart(string id, string userId)
        {
            var product = this.db.Products.FirstOrDefault(p => p.Id == id);

            var user = this.db.Users.Include(c => c.Cart).FirstOrDefault(u => u.Id == userId);

            user.Cart.Products.Add(product);
            this.db.SaveChanges();
        }

        public void ClearCart(string id)
        {
            var user = this.db.Users
               .Include(c => c.Cart)
                .ThenInclude(p => p.Products)
               .FirstOrDefault(x => x.Id == id);

            user.Cart.Products.Clear();
            this.db.SaveChanges();
        }

        public IEnumerable<Product> GetUsersCartItems(string id)
        {
            var user = this.db.Users
                .Include(c => c.Cart)
                .ThenInclude(p => p.Products)
                .FirstOrDefault(x => x.Id == id);

            var products = user.Cart.Products.ToList();

            return products;
        }
    }
}
