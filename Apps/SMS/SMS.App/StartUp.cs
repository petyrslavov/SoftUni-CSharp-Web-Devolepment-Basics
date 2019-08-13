namespace SMS.App
{
    using System;
    using Data;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Routing;
    using SMS.Services;
    using IServiceProvider = SIS.MvcFramework.DependencyContainer.IServiceProvider;

    public class StartUp : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var db = new SMSContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IProductService, ProductService>();
            serviceProvider.Add<ICartService, CartService>();
        }
    }
}