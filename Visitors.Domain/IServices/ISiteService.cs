
namespace Visitors.Domain.IServices
{
    public interface ISiteService
    {
        Task<string> Create(string? name = null);
        Task<byte[]> Track(string siteId, string visitorIP);
    }
}
