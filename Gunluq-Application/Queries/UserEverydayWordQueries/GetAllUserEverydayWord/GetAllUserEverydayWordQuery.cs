using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetAllUserEverydayWord
{
    public record GetAllUserEverydayWordQuery() : IRequest<ApplicationResponse<List<GetAllUserEverydayWordResponse>>>;
}
