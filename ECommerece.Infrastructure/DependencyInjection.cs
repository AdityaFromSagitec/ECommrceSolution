//install the package Microsoft.Extensions.DependencyInjection.Abstractions
using Microsoft.Extensions.DependencyInjection;

namespace ECommerece.Infrastructure;
public static class DependencyInjection // Changed to static class
{

    // Extension method to add infrastructure services to the IServiceCollection container via Dependency Injection
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //To DO : add services to the Ioc container 
        //Infrastructure services often include database contexts, repositories, logging services, caching services, and other cross-cutting concerns.
        return services;
    }
}