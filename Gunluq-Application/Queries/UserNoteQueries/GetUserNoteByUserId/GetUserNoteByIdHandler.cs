using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserNoteQueries.GetUserNoteByUserId
{
    public class GetUserNoteByIdHandler : IRequestHandler<GetUserNoteByIdQuery, ApplicationResponse<GetUserNoteByIdResponse>>
    {
        private readonly IUserNoteRepository _userNoteRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserDiaryCrypto _userCrypto;

        public GetUserNoteByIdHandler(IUserNoteRepository userNoteRepository, IUserRepository userRepository, UserDiaryCrypto userCrypto)
        {
            _userNoteRepository = userNoteRepository;
            _userRepository = userRepository;
            _userCrypto = userCrypto;
        }

        public async Task<ApplicationResponse<GetUserNoteByIdResponse>> Handle(GetUserNoteByIdQuery userNoteByUserIdQuery, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(userNoteByUserIdQuery.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<GetUserNoteByIdResponse>.Fail(UserMessages.UserNotFound);

            UserNote? foundUserNote = await _userNoteRepository.GetUserNoteByIdAsync(userNoteByUserIdQuery.UserNoteId, cancellationToken);
            if (foundUserNote is null) return ApplicationResponse<GetUserNoteByIdResponse>.Fail(UserNoteMessages.UserNoteNotFound);

            string decryptedContent = _userCrypto.DecryptDiary(foundUserNote.Content, foundUser.EncryptedDek, foundUser.UserCode, foundUser.Salt);

            return ApplicationResponse<GetUserNoteByIdResponse>.Ok(new GetUserNoteByIdResponse 
            {
                Id = foundUserNote.Id,
                UserId = foundUserNote.UserId,
                Content = decryptedContent,
                CreatedDate = foundUserNote.CreatedDate,
                UpdatedDate = foundUserNote.UpdatedDate,
                DeletedDate = foundUserNote.DeletedDate,
                Status = foundUserNote.Status
            }, UserNoteMessages.UserNoteFound);
        }
    }
}
