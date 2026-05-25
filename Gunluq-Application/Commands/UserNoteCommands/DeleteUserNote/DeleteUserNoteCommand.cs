using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserNoteCommands.DeleteUserNote
{
    public record DeleteUserNoteCommand(Guid UserId, Guid UserNoteId) : IRequest<ApplicationResponse<DeleteUserNoteResponse>>;
}
