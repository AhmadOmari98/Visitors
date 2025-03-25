namespace Common
{
    public class DomainEntity
    {
        public int? CreatedBy { get; set; } = null;
        public int? UpdatedBy { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = null;
        public DateTime? UpdatedDate { get; set; } = null;
        public bool IsPublished { get; set; } = false;
        public bool IsActivated { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
