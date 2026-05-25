using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserQueries.GetUserByEmail
{
    public record GetUserByEmailQuery(string Email) : IRequest<ApplicationResponse<GetUserByEmailResponse>>;
}
