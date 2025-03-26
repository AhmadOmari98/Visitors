using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using Visitors.Domain.IServices;
using Visitors.Domain.Models.Response;

namespace Visitors.Infra.Services
{
    public class GeoService : IGeoService
    {
        // HTTP client instance to make HTTP requests
        private readonly HttpClient _httpClient;

        // IConfiguration instance to read values from appsettings.json
        private readonly IConfiguration _configuration;

        // Constructor to inject HttpClient and IConfiguration
        public GeoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        //---------------------------------------------**
        // Method to get visitor address details by IP
        public async Task<VisitorAddressDetails> GetVisitorAddressDetailsByIP(string ip)
        {
            try
            {
                // Retrieve the API URL from the configuration (appsettings.json)
                string apiUrl = _configuration.GetValue<string>("GeoService:ApiUrl")
                                ?? throw new Exception("API URL is not configured.");

                // Format the URL with the visitor's IP address
                var url = string.Format(apiUrl, ip);

                // Make the GET request to the external API and deserialize the response into VisitorAddressDetails
                var response = await _httpClient.GetFromJsonAsync<VisitorAddressDetails>(url);

                // Return the response or an empty object if the response is null
                return response ?? new VisitorAddressDetails();
            }
            catch (Exception ex)
            {
                // Log the exception (optional) and return an empty VisitorAddressDetails object on error
                // (Logging not included for simplicity)
                return new VisitorAddressDetails();
            }
        }
    }
}
