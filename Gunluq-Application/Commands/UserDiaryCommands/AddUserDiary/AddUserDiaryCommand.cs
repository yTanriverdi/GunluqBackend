using Gunluq_Application.ApplicationResponse;
using Gunluq_Domain.Enums;
using MediatR;

namespace Gunluq_Application.Commands.UserDiaryCommands.AddUserDiary
{
    public record AddUserDiaryCommand(
        Guid UserId,
        string Content,
        Feel Feel,
        DiaryTag DiaryTag
        ) : IRequest<ApplicationResponse<AddUserDiaryResponse>>;
}
