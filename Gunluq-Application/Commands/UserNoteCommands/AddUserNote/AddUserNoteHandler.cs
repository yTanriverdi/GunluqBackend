using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserNoteCommands.AddUserNote
{
    public class AddUserNoteHandler : IRequestHandler<AddUserNoteCommand, ApplicationResponse<AddUserNoteResponse>>
    {
        private readonly IUserNoteRepository _userNoteRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserDiaryCrypto _userDiaryCrypto;

        public AddUserNoteHandler(IUserNoteRepository userNoteRepository, IUserRepository userRepository, UserDiaryCrypto userDiaryCrypto)
        {
            _userNoteRepository = userNoteRepository;
            _userRepository = userRepository;
            _userDiaryCrypto = userDiaryCrypto;
        }

        public async Task<ApplicationResponse<AddUserNoteResponse>> Handle(AddUserNoteCommand addUserNoteCommand, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(addUserNoteCommand.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<AddUserNoteResponse>.Fail(UserMessages.UserNotFound);

            string encryptedContent = _userDiaryCrypto.EncryptDiary(addUserNoteCommand.Content, foundUser.EncryptedDek, foundUser.UserCode, foundUser.Salt);

            UserNote newUserNote = new UserNote
            {
                UserId = addUserNoteCommand.UserId,
                Content = encryptedContent
            };

            UserNote addedUserNote = await _userNoteRepository.AddUserNoteAsync(newUserNote, cancellationToken);

            return ApplicationResponse<AddUserNoteResponse>.Ok(new AddUserNoteResponse
            {
                Id = addedUserNote.Id,
                UserId = addedUserNote.UserId,
                Content = addUserNoteCommand.Content,
                CreatedDate = addedUserNote.CreatedDate,
                UpdatedDate = addedUserNote.UpdatedDate,
                DeletedDate = addedUserNote.DeletedDate
            }, UserNoteMessages.AddUserNoteSuccess);
        }
    }
}
