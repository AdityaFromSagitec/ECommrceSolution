using ECommerce.Core.ServiceContracts;
using ECommerce.Core.Services;
using ECommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core;
    public static class DependencyInjection // Changed to static class
    {
    // Extension method to add core services to the IServiceCollection container via Dependency Injection
    public static IServiceCollection AddCore(this IServiceCollection services)
        {
            //To DO : add services to the Ioc container 
            //Infrastructure services often include database contexts, repositories, logging services, caching services, and other cross-cutting concerns.

        services.AddTransient<IUserService,UserService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
        }
    }

