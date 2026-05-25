namespace Gunluq_Application.Commands.UserEverydayWordCommands.AddUserEverydayWord
{
    public sealed class AddUserEverydayWordResponse
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
