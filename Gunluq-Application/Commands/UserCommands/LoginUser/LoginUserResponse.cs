using Gunluq_Domain.Enums;

namespace Gunluq_Application.Commands.UserCommands.LoginUser
{
    public class LoginUserResponse
    {
        public Guid UserId { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public Role Role { get; set; }
        public string JwtToken { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
