using Visitors.Domain.Entity;

namespace Visitors.Domain.Mapping
{
    public static class VisitMapping
    {
        public static Visit ToVisit(this string visitorIP, string visitorCity, string visitorRegion, string visitorCountry)
        {
            return new Visit(visitorIP: visitorIP,
                             visitorCity: visitorCity,
                             visitorRegion: visitorRegion,
                             visitorCountry: visitorCountry);
        }
    }
}
