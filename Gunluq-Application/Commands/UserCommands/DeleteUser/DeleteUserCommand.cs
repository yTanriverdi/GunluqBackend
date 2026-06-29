using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.DeleteUser
{
    public record DeleteUserCommand(Guid UserId, string Password) : IRequest<ApplicationResponse<DeleteUserResponse>>;
}
