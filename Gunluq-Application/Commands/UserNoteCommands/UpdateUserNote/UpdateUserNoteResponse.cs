namespace Gunluq_Application.Commands.UserNoteCommands.UpdateUserNote
{
    public class UpdateUserNoteResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
