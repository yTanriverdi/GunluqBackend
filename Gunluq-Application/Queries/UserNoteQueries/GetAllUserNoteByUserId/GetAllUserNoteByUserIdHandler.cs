using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.Queries.UserEverydayWordQueries.GetUserEverydayWordById;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using System.Collections.Generic;

namespace Gunluq_Application.Queries.UserNoteQueries.GetAllUserNoteByUserId
{
    public class GetAllUserNoteByUserIdHandler
    {
        private readonly IUserNoteRepository _userNoteRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserDiaryCrypto _userCrypto;

        public GetAllUserNoteByUserIdHandler(IUserNoteRepository userNoteRepository, IUserRepository userRepository, UserDiaryCrypto userCrypto)
        {
            _userNoteRepository = userNoteRepository;
            _userRepository = userRepository;
            _userCrypto = userCrypto;
        }

        public async Task<ApplicationResponse<List<GetAllUserNoteByUserIdResponse>>> Handle(GetAllUserNoteByUserIdQuery getAllUserNoteByUserIdQuery, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(getAllUserNoteByUserIdQuery.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<List<GetAllUserNoteByUserIdResponse>>.Fail(UserMessages.UserNotFound);

            List<UserNote> userNotes = await _userNoteRepository.GetAllUserNoteByUserIdAsync(foundUser.Id, cancellationToken);
            if (!userNotes.Any()) return ApplicationResponse<List<GetAllUserNoteByUserIdResponse>>.Fail(UserNoteMessages.UserNotesNotFound);

            List<GetAllUserNoteByUserIdResponse> getAllUserNoteByUserIdResponses = userNotes.Select(x => new GetAllUserNoteByUserIdResponse
            {
                Id = x!.Id,
                UserId = x.UserId,
                Content = _userCrypto.DecryptDiary(x.Content, foundUser.EncryptedDek, foundUser.UserCode, foundUser.Salt),
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                Status = x.Status,
            }).ToList();

            return ApplicationResponse<List<GetAllUserNoteByUserIdResponse>>.Ok(getAllUserNoteByUserIdResponses, UserNoteMessages.UserNotesFound);
        }
    }
}
