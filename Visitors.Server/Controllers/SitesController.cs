using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Visitors.Domain.IServices;

namespace Visitors.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SitesController : ControllerBase
    {
        private readonly ISiteService _service;

        public SitesController(ISiteService service)
        {
            _service = service;
        }
        //---------------------------------------------**
        [HttpPost("create/{name?}")]
        [AllowAnonymous]
        public async Task<string> Create(string? name = null)
        {
            var siteId = await _service.Create(name);
            return siteId;
        }
    }
}
