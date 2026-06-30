using Gunluq_Application.ApplicationResponse;
using Gunluq_Domain.DTOs;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAnalysis
{
    public record GetAnalysisQuery(Guid UserId) : IRequest<ApplicationResponse<GetAnalysisResponse>>;
}
