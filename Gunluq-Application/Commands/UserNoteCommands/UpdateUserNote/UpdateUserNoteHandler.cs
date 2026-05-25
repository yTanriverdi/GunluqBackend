using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Commands.UserNoteCommands.AddUserNote;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserNoteCommands.UpdateUserNote
{
    public class UpdateUserNoteHandler : IRequestHandler<UpdateUserNoteCommand, ApplicationResponse<UpdateUserNoteResponse>>
    {
        private readonly IUserNoteRepository _userNoteRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserDiaryCrypto _userDiaryCrypto;

        public UpdateUserNoteHandler(IUserNoteRepository userNoteRepository, IUserRepository userRepository, UserDiaryCrypto userDiaryCrypto)
        {
            _userNoteRepository = userNoteRepository;
            _userRepository = userRepository;
            _userDiaryCrypto = userDiaryCrypto;
        }

        public async Task<ApplicationResponse<UpdateUserNoteResponse>> Handle(UpdateUserNoteCommand updateUserNoteCommand, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(updateUserNoteCommand.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<UpdateUserNoteResponse>.Fail(UserMessages.UserNotFound);

            UserNote? forUpdateUserNote = await _userNoteRepository.GetUserNoteByIdAsync(updateUserNoteCommand.UserNoteId, cancellationToken);
            if (forUpdateUserNote is null) return ApplicationResponse<UpdateUserNoteResponse>.Fail(UserNoteMessages.UserNoteNotFound);
            string encryptedContent = _userDiaryCrypto.EncryptDiary(updateUserNoteCommand.Content, foundUser.EncryptedDek, foundUser.UserCode, foundUser.Salt);

            forUpdateUserNote.Content = encryptedContent;
            UserNote updatedUserNote = await _userNoteRepository.UpdateUserNoteAsync(forUpdateUserNote, cancellationToken);
            return ApplicationResponse<UpdateUserNoteResponse>.Ok(new UpdateUserNoteResponse
            {
                Id = updatedUserNote.Id,
                UserId = updatedUserNote.UserId,
                Content = updateUserNoteCommand.Content,
                CreatedDate = updatedUserNote.CreatedDate,
                UpdatedDate = updatedUserNote.UpdatedDate,
                DeletedDate = updatedUserNote.DeletedDate,
            }, UserNoteMessages.UserNoteUpdateSuccess);
        }
    }
}
