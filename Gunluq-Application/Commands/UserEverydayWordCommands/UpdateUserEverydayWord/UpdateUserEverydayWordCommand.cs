using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserEverydayWordCommands.UpdateEverydayWord
{
    public record UpdateUserEverydayWordCommand(Guid UserId, Guid UserEverydayWordId, string Content) : IRequest<ApplicationResponse<UpdateUserEverydayWordResponse>>;
}
