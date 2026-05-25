namespace Gunluq_Application.Commands.UserDiaryCommands.DeleteUserDiary
{
    public sealed class DeleteUserDiaryResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
