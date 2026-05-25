using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Commands.UserDiaryCommands.DeleteUserDiary
{
    public record DeleteUserDiaryCommand(Guid UserId, Guid UserDiaryId) : IRequest<ApplicationResponse<DeleteUserDiaryResponse>>;
}
