using Application.Data;
using Domain;
using Domain.Primitive;
using Infrastructure.Persistance.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.API.Middlewares;

namespace Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<GloblalExceptionHandlingMiddleware>();

            return services;
        }
    }
}
