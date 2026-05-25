using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserNoteQueries.GetAllUserNote
{
    public record GetAllUserNoteQuery() : IRequest<ApplicationResponse<List<GetAllUserNoteResponse>>>;
}
