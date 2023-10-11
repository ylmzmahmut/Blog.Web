using System.Reflection;
using BlogWeb.Service.Helpers;
using BlogWeb.Service.Services.Abstractions;
using BlogWeb.Service.Services.Concretes;

namespace WebApplicationApi.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IArticelService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIamgeHelper, ImageHelper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(assembly);

          

            return services;

        }
    }
}
