using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.ChangePassword
{
    public record ChangePasswordCommand(
        Guid UserId,
        string NewPassword,
        string OldPassword
        ) : IRequest<ApplicationResponse<ChangePasswordResponse>>;
}
