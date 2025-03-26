using Visitors.Domain.Entity;
using Visitors.Domain.IRepositories;
using Visitors.Domain.IServices;
using Visitors.Domain.Mapping;
using SkiaSharp;

namespace Visitors.Infra.Services
{
    public class SiteService : ISiteService
    {
        private readonly IRepository<Site> _repository;
        private readonly IGeoService _geoService;
        public SiteService(IRepository<Site> repository, IGeoService geoService)
        {
            _repository = repository;
            _geoService = geoService;
        }

        //---------------------------------------------**
        public async Task<string> Create(string? name = null)
        {
            var newSite = name.ToSite();
            await _repository.AddAsync(newSite);
            return newSite.Id.ToString();
        }
        public async Task<byte[]> Track(string siteId, string visitorIP)
        {
            // Retrieve the site by its ID from the repository
            var site = await _repository.GetByIdAsync(Guid.Parse(siteId));

            // If the site is not found, throw an exception
            if (site == null)
                throw new Exception("Site not found");

            // Get the visitor's address details by their IP
            var visitorAddressDetails = await _geoService.GetVisitorAddressDetailsByIP(visitorIP);

            // Create a new visit object using the visitor's IP and address details (City, Region, Country)
            var visit = visitorIP.ToVisit(visitorAddressDetails.City, visitorAddressDetails.Region, visitorAddressDetails.Country);

            // Add the visit to the site
            site.AddVisit(visit);

            // Save the site and its visit data to the repository
            await _repository.SaveAsync();

            // Group the visits by country and count the number of visits for each country
            var countryStats = site.Visits
                .GroupBy(v => v.VisitorCountry) // Group visits by country
                .Select(g => new { Country = g.Key, Count = g.Count() }) // Select country and visit count
                .ToList();

            // Create a new image (400x200 pixels) to draw the country stats
            using var image = new SKBitmap(400, 200);
            using var canvas = new SKCanvas(image);
            canvas.Clear(SKColors.White); // Clear the canvas and set the background to white

            // Set the paint (color) and font for the text
            var paint = new SKPaint { Color = SKColors.Black };
            var font = new SKFont(SKTypeface.Default, 20); // Font size 20

            // Start drawing text on the image at y = 30
            int y = 30;
            foreach (var stat in countryStats)
            {
                // Draw each country and its corresponding visit count
                canvas.DrawText($"{stat.Country}: {stat.Count}", 10, y, SKTextAlign.Left, font, paint);
                y += 30; // Move the Y position for the next line of text
            }

            // Convert the image to a byte array in PNG format
            using var imageStream = new MemoryStream();
            using var skImage = SKImage.FromBitmap(image);
            using var data = skImage.Encode(SKEncodedImageFormat.Png, 100); // Set PNG quality to 100
            data.SaveTo(imageStream);

            // Return the byte array representing the image
            return imageStream.ToArray();
        }

    }
}


