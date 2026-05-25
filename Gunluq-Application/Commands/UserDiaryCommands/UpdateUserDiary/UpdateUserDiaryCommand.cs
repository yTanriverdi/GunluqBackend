using Gunluq_Application.ApplicationResponse;
using Gunluq_Domain.Enums;
using MediatR;

namespace Gunluq_Application.Commands.UserDiaryCommands.UpdateUserDiary
{
    public record UpdateUserDiaryCommand(
        Guid UserId,
        Guid UserDiaryId,
        string Content,
        DiaryTag DiaryTag,
        Feel Feel
        ) : IRequest<ApplicationResponse<UpdateUserDiaryResponse>>;
}