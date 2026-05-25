using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserNoteQueries.GetAllUserNote
{
    public class GetAllUserNoteHandler : IRequestHandler<GetAllUserNoteQuery, ApplicationResponse<List<GetAllUserNoteResponse>>>
    {
        private readonly IUserNoteRepository _userNoteRepository;

        public GetAllUserNoteHandler(IUserNoteRepository userNoteRepository)
        {
            _userNoteRepository = userNoteRepository;
        }

        public async Task<ApplicationResponse<List<GetAllUserNoteResponse>>> Handle(GetAllUserNoteQuery getAllUserNoteQuery, CancellationToken cancellationToken)
        {
            List<UserNote> userNotes = await _userNoteRepository.GetAllUserNoteAsnc(cancellationToken);
            if (!userNotes.Any()) return ApplicationResponse<List<GetAllUserNoteResponse>>.Fail(UserNoteMessages.UserNotesNotFound);

            List<GetAllUserNoteResponse> getAllUserNoteResponses = userNotes.Select(x => new GetAllUserNoteResponse
            {
                Id = x!.Id,
                UserId = x.UserId,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                Status = x.Status
            }).ToList();

            return ApplicationResponse<List<GetAllUserNoteResponse>>.Ok(getAllUserNoteResponses, UserNoteMessages.UserNotesFound);
        }
    }
}
