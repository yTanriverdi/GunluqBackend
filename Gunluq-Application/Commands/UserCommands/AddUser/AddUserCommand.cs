using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.AddUser
{
    public record AddUserCommand(
        string Email,
        string UserName,
        string FirstName,
        string LastName,
        string Password) : IRequest<ApplicationResponse<AddUserResponse>>;
}
