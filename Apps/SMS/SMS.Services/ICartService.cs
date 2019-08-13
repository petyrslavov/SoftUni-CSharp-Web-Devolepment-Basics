using SMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Services
{
    public interface ICartService
    {
        void AddToCart(string id, string userId);

        IEnumerable<Product> GetUsersCartItems(string id);

        void ClearCart(string id);
    }
}
