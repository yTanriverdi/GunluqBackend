using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetAllUserEverydayWordByUserId
{
    public record GetAllUserEverydayWordByUserIdQuery(Guid UserId) : IRequest<ApplicationResponse<List<GetAllUserEverydayWordByUserIdResponse>>>;
}
