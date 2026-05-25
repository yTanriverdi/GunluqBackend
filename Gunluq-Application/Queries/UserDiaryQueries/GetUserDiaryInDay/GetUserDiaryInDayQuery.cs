using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetUserDiaryInDay
{
    public record GetUserDiaryInDayQuery(Guid UserId) : IRequest<ApplicationResponse<GetUserDiaryInDayResponse>>;
}
