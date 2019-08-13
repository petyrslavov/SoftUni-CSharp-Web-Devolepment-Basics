namespace SMS.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using SMS.App.ViewModels.ProductsModels;
    using SMS.Services;

    public class HomeController : BaseController
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = productService.GetAllProducts();

            List<ProductListingModel> viewModel = products
                .Select(product => new ProductListingModel
                {
                    Id= product.Id,
                    Name = product.Name,
                    Price = product.Price
                })
                .ToList();


            if (this.IsLoggedIn())
            {
                return this.View(viewModel, "IndexLoggedIn");
            }
            else
            {
                return this.View(viewModel);
            }
        }
    }
}