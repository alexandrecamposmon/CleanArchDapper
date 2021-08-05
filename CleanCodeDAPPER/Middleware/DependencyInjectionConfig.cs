using CleanCodeDAPPER.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;


namespace CleanCodeDapper.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<BDContext>();


            return services;
        }
    }
}