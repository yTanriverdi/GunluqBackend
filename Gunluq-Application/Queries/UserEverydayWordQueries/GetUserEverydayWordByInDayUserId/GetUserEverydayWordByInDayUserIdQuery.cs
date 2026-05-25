using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetUserEverydayWordByInDayUserId
{
    public record GetUserEverydayWordByInDayUserIdQuery(Guid UserId) : IRequest<ApplicationResponse<GetUserEverydayWordByInDayUserIdResponse>>;
}
