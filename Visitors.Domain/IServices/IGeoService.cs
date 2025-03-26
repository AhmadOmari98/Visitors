
using Visitors.Domain.Models.Response;

namespace Visitors.Domain.IServices
{
    public interface IGeoService
    {
        Task<VisitorAddressDetails> GetVisitorAddressDetailsByIP(string ip);
    }
}
