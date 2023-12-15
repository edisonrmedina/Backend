using Application;
using Application.Data;
using Domain;
using Domain.Primitive;
using Infrastructure.Persistance.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IAccountRepository, AccountRespository>();
            services.AddScoped<IMovementRepository, MovementRespository>();

            services.Configure<ApiUrl>(options =>
            {
                configuration.GetSection("ApiUrls").Bind(options);
            });

            services.AddHttpClient<IClientProx, ClientProxy>();


            return services;
        }
    }
}
