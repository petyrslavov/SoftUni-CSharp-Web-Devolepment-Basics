using System.Collections.Generic;

namespace SMS.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Products = new List<Product>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}