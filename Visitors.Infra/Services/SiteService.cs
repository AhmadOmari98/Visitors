using Visitors.Domain.Entity;
using Visitors.Domain.IRepositories;
using Visitors.Domain.IServices;
using Visitors.Domain.Mapping;

namespace Visitors.Infra.Services
{
    public class SiteService : ISiteService
    {
        private readonly IRepository<Site> _repository;

        public SiteService(IRepository<Site> repository)
        {
            _repository = repository;
        }

        //---------------------------------------------**
        public async Task<string> Create(string? name = null)
        {
            var newSite = name.ToSite();
            await _repository.AddAsync(newSite);
            var s = newSite.Id;
            return newSite.Id.ToString();
        }
    }
}
