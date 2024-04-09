using FilmoSearch.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace FilmoSearch.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<FilmoSearchDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IFilmoSearchDbContext>(provider =>
                provider.GetService<FilmoSearchDbContext>());
            return services;
        } 
    }
}
