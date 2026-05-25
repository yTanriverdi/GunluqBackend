using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserNoteQueries.GetAllUserNoteByUserId
{
    public record GetAllUserNoteByUserIdQuery(Guid UserId) : IRequest<ApplicationResponse<List<GetAllUserNoteByUserIdResponse>>>;
}
