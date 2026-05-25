using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetUserEverydayWordById
{
    public record GetUserEverydayWordByIdQuery(Guid UserId, Guid UserEverydayWordId) : IRequest<ApplicationResponse<GetUserEverydayWordByIdResponse>>;
   
}
