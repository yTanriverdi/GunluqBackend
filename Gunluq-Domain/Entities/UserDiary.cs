using Gunluq_Domain.BaseEntities;
using Gunluq_Domain.Enums;

namespace Gunluq_Domain.Entities
{
    public class UserDiary : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public required string Content { get; set; } = default!;
        public required Feel Feel { get; set; }
        public required DiaryTag DiaryTag { get; set; }
    }
}
