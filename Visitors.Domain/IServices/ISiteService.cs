
namespace Visitors.Domain.IServices
{
    public interface ISiteService
    {
        Task<string> Create(string? name = null);
    }
}
