namespace Gunluq_Application.Commands.UserCommands.UpdateUser
{
    public sealed class UpdateUserResponse
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
