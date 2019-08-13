using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SMS.App.ViewModels.ProductsModels;
using SMS.Services;
using System.Collections.Generic;
using System.Linq;

namespace SMS.App.Controllers
{
    public class CartsController : BaseController
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddProduct(string productId)
        {
            var userId = this.User.Id;

            cartService.AddToCart(productId, userId);

            return this.Redirect("/Carts/Details");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details()
        {
            var userId = this.User.Id;

            var products = cartService.GetUsersCartItems(userId);

            List<ProductListingModel> viewModel = products
               .Select(product => new ProductListingModel
               {
                   Name = product.Name,
                   Price = product.Price
               })
               .ToList();

            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Buy()
        {
            var userId = this.User.Id;

            cartService.ClearCart(userId);

            return this.Redirect("/");
        }
    }
}