using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByUserId
{
    public record GetAllUserDiaryByUserIdQuery(Guid UserId) : IRequest<ApplicationResponse<List<GetAllUserDiaryByUserIdResponse>>>;
}
