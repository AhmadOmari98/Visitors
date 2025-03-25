using Common;

namespace Visitors.Domain.Entity
{
    public class Site : DomainEntity
    {
        protected Site() { }
        public Site(string? name = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedAt = DateTime.Now;
        }
        public Guid Id { get; private set; } 
        public string? Name { get; private set; } = null;
        public DateTime CreatedAt { get; private set; }

        private readonly List<Visit> _visits = new();
        public virtual IReadOnlyCollection<Visit> Visits => _visits.AsReadOnly();

        //--------------------------*
        internal void AddVisit(Visit visit)
        {
            _visits.Add(visit);
        }
    }
}
