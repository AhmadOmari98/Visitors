using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Visitors.Infra.EntitiesConfigurations
{
    public static class ModelBuilderProvider
    {
        public static void AddModelBuilderConfigrations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
