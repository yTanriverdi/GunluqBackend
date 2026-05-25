using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserQueries.GetAllUsers
{
    public record GetAllUsersQuery() : IRequest<ApplicationResponse<List<GetAllUsersResponse>>>;
}
