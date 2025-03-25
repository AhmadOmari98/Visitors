using Microsoft.Extensions.DependencyInjection;
using Visitors.Domain.IServices;
using Visitors.Infra.Services;

namespace Visitors.Infra
{
    public static class DependencyInjection_AddServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<ISiteService, SiteService>();
        }
    }
}
