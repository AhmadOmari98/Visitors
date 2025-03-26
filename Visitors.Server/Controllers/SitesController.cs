using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
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
            return await _service.Create(name);
        }

        [HttpGet("track/{siteId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Track(string siteId)
        {
            string visitorIP = "Unknown"; // Default to "Unknown" if no IP is found

            // Get the remote IP address from the HTTP context
            var remoteIp = HttpContext.Connection.RemoteIpAddress;

            // Check if the remote IP address is available
            if (remoteIp != null)
            {
                // If it's an IPv6 loopback address (localhost), change it to IPv4 loopback (127.0.0.1)
                if (remoteIp.AddressFamily == AddressFamily.InterNetworkV6 && remoteIp.ToString() == "::1")
                {
                    //visitorIP = "127.0.0.1"; // Use localhost (IPv4) for development environments
                    visitorIP = "82.212.78.93";
                }
                else
                {
                    visitorIP = remoteIp.ToString(); // Use the remote IP address
                }
            }

            // Call the service to track the visit, passing the siteId and visitorIP
            var imageBytes = await _service.Track(siteId, visitorIP);

            // Return the generated image as a PNG file
            return File(imageBytes, "image/png");
        }

    }
}
