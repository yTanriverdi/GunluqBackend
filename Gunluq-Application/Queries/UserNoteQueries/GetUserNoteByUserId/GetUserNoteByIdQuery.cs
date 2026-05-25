using Gunluq_Application.ApplicationResponse;
using MediatR;

namespace Gunluq_Application.Queries.UserNoteQueries.GetUserNoteByUserId
{
    public record GetUserNoteByIdQuery(Guid UserId, Guid UserNoteId) : IRequest<ApplicationResponse<GetUserNoteByIdResponse>>;
}
