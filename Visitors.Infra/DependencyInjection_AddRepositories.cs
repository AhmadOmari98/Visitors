using Microsoft.Extensions.DependencyInjection;
using Visitors.Domain.IRepositories;
using Visitors.Infra.Repositories;

namespace Visitors.Infra
{
    public static class DependencyInjection_AddRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        }
    }
}
