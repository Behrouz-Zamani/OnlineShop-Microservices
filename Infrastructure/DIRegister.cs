using Core.IRepositories;
using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DIRegister
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository,ProductRepository>();
    }

    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork,UnitOfWork>();
    }
}