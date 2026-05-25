namespace Gunluq_Application.Commands.UserDiaryCommands.UpdateUserDiary
{
    public sealed class UpdateUserDiaryResponse
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
