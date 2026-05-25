using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.LoginUser
{
    public record LoginUserCommand(string Email, string Password) : IRequest<ApplicationResponse<LoginUserResponse>>;
}
