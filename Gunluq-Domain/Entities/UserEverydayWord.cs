using Gunluq_Domain.BaseEntities;

namespace Gunluq_Domain.Entities
{
    public class UserEverydayWord : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public required string Content { get; set; } = default!;
    }
}
