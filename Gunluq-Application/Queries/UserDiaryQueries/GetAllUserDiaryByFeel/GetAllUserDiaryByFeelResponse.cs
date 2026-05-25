using Gunluq_Domain.Enums;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByFeel
{
    public sealed class GetAllUserDiaryByFeelResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string Content { get; set; }
        public Feel Feel { get; set; }
        public DiaryTag DiaryTag { get; set; }
        public required Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
