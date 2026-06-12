using Gunluq_Domain.Enums;

namespace Gunluq_Application.Commands.UserDiaryCommands.UpdateUserDiary
{
    public sealed class UpdateUserDiaryResponse
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required string Content { get; set; }
        public required DiaryTag DiaryTag { get; set; }
        public required Feel Feel { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
