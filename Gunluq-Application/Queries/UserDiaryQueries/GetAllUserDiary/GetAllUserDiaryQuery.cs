using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiary
{
    public record GetAllUserDiaryQuery() : IRequest<ApplicationResponse<List<GetAllUserDiaryResponse>>>;
}
