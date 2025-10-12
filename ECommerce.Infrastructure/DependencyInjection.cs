//install the package Microsoft.Extensions.DependencyInjection.Abstractions
using System.Net.Security;
using ECommerce.Core.RepositoryContracts;
using ECommerce.Infrastructure.DBContext;
using ECommerece.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerece.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<DapperDBContext>();
        return services;
    }
}