using Visitors.Domain.Entity;

namespace Visitors.Domain.Mapping
{
    public static class SiteMapping
    {
        public static Site ToSite(this string? name)
        {
            return new Site(name: name);
        }
    }
}
