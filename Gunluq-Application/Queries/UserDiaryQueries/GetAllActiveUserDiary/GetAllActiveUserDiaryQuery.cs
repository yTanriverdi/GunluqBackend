using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllActiveUserDiary
{
    public record GetAllActiveUserDiaryQuery() : IRequest<ApplicationResponse<List<GetAllActiveUserDiaryResponse>>>;
}
