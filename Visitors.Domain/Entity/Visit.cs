using Common;

namespace Visitors.Domain.Entity
{
    public class Visit : DomainEntity
    {
        protected Visit() { }
        public Visit(string visitorIP, string visitorCity, string visitorRegion, string visitorCountry)
        {
            Id = Guid.NewGuid();
            VisitorIP = visitorIP;
            VisitorCity = visitorCity;
            VisitorRegion = visitorRegion;
            VisitorCountry = visitorCountry;
            VisitedAt = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public string VisitorIP { get; private set; } = string.Empty;
        public string VisitorCity { get; private set; } = string.Empty;
        public string VisitorRegion { get; private set; } = string.Empty;
        public string VisitorCountry { get; private set; } = string.Empty;
        public DateTime VisitedAt { get; private set; }
        public Guid SiteId { get; set; }
    }
}
