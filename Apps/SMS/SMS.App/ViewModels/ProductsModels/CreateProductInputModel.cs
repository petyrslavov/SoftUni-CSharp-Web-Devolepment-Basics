using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.App.ViewModels.ProductsModels
{
    public class CreateProductInputModel
    {
        [RequiredSis]
        [StringLengthSis(4, 20, "Product name should be between 4 and 20 characters")]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
