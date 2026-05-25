namespace Gunluq_Application.Commands.UserCommands.DeleteUser
{
    public sealed class DeleteUserResponse
    {
        public Guid Id { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
