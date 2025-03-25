using Common;

namespace Visitors.Domain.Entity
{
    public class Visit : DomainEntity
    {
        protected Visit() { }
        public Visit(string visitorIP, string country)
        {
            Id = Guid.NewGuid();
            VisitorIP = visitorIP;
            VisitorCountry = country;
            VisitedAt = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public string VisitorIP { get; private set; }
        public string VisitorCountry { get; private set; }
        public DateTime VisitedAt { get; private set; }
        public Guid SiteId { get; set; }
    }
}
