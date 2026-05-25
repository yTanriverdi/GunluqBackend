using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserQueries.GetUserByUserName
{
    public record GetUserByUserNameQuery(string UserName) : IRequest<ApplicationResponse<GetUserByUserNameResponse>>;
}
