using BookShop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")!;
            services.AddDbContext<BookShopDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b=>b.MigrationsAssembly("BookShop.Presentation"));
            });
            services.AddScoped<IBookShopDbContext>(provider =>  
                provider.GetService<BookShopDbContext>()!);

            return services;
        }
    }
}
