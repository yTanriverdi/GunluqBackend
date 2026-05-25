using Gunluq_Application.ApplicationResponse;
using Gunluq_Domain.Enums;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByFeel
{
    public record GetAllUserDiaryByFeelQuery(Feel Feel) : IRequest<ApplicationResponse<List<GetAllUserDiaryByFeelResponse>>>;
}
