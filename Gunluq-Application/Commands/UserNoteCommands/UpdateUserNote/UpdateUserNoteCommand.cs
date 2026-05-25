using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserNoteCommands.UpdateUserNote
{
    public record UpdateUserNoteCommand(Guid UserId, Guid UserNoteId, string Content) : IRequest<ApplicationResponse<UpdateUserNoteResponse>>;
}
