using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.UpdateUser
{
    public record UpdateUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string UserName
        ) : IRequest<ApplicationResponse<UpdateUserResponse>>;
}
