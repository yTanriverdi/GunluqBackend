using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserNoteCommands.AddUserNote
{
    public record AddUserNoteCommand(Guid UserId, string Content) : IRequest<ApplicationResponse<AddUserNoteResponse>>;
}
