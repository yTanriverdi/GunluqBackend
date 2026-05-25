using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserEverydayWordCommands.AddUserEverydayWord
{
    public record AddUserEverydayWordCommand(Guid UserId, string Content) : IRequest<ApplicationResponse<AddUserEverydayWordResponse>>;
}
