using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.ChangeUserRole
{
    public record ChangeUserRoleCommand(Guid UserId) : IRequest<ApplicationResponse<ChangeUserRoleResponse>>;
}
