using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserQueries.GetUserById
{
    public record GetUserByIdQuery(Guid UserId) : IRequest<ApplicationResponse<GetUserByIdResponse>>;
}