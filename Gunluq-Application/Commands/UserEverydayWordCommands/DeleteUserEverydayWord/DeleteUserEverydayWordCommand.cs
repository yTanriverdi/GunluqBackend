using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserEverydayWordCommands.DeleteUserEverydayWord
{
    public record DeleteUserEverydayWordCommand(Guid UserId, Guid UserEverydayWordId) : IRequest<ApplicationResponse<DeleteUserEverydayWordResponse>>;
}
