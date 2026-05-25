using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetAllEverydayWordByInDay
{
    public record GetAllUserEverydayWordByInDayQuery() : IRequest<ApplicationResponse<List<GetAllUserEverydayWordByInDayResponse>>>;
}
