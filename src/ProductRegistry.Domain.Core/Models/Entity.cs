namespace ProductRegistry.Domain.Core.Models
{
    public class Entity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
