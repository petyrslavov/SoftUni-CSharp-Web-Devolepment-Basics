using SIS.MvcFramework.Attributes.Validation;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Product
    {
        public string Id { get; set; }

        [RequiredSis]
        [StringLengthSis(4, 20, "Product name should be between 4 and 20 characters")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [RequiredSis]
        public string CartId { get; set; }
        public Cart Cart { get; set; }
    }
}