using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetUserDiaryById
{
    public record GetUserDiaryByIdQuery(Guid UserDiaryId, Guid UserId) : IRequest<ApplicationResponse<GetUserDiaryByIdResponse>>;
}
