using Microsoft.Extensions.DependencyInjection;
using Visitors.Domain.IServices;
using Visitors.Infra.Services;

namespace Visitors.Infra
{
    public static class DependencyInjection_AddServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISiteService, SiteService>();

            // Add the HttpClient for IGeoService separately
            services.AddHttpClient<IGeoService, GeoService>();

            return services;
        }
    }
}
