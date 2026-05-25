using Gunluq_Application.ApplicationResponse;
using Gunluq_Domain.Enums;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByDiaryTag
{
    public record GetAllUserDiaryByDiaryTagQuery(DiaryTag DiaryTag) : IRequest<ApplicationResponse<List<GetAllUserDiaryByDiaryTagResponse>>>;
}
