using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tech.BusinessLogic.Abstract;
using Tech.BusinessLogic.Concrete;
using Tech.DataAccess.Abstract.Products;
using Tech.DataAccess.Concrete.EntityFrameworkRepositories.Products;

namespace Tech.BusinessLogic.Ioc
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

          
        }
    }
}
