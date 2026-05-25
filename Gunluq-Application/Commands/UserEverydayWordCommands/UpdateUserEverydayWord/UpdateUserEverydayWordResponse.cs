namespace Gunluq_Application.Commands.UserEverydayWordCommands.UpdateEverydayWord
{
    public sealed class UpdateUserEverydayWordResponse
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
