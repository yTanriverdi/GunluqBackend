using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserDiaryCommands.AddUserDiary
{
    public class AddUserDiaryHandler : IRequestHandler<AddUserDiaryCommand, ApplicationResponse<AddUserDiaryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDiaryRepository _userDiaryRepository;
        private readonly UserDiaryCrypto _userDiaryCrypto;

        public AddUserDiaryHandler(IUserRepository userRepository, IUserDiaryRepository userDiaryRepository, UserDiaryCrypto userDiaryCrypto)
        {
            _userRepository = userRepository;
            _userDiaryRepository = userDiaryRepository;
            _userDiaryCrypto = userDiaryCrypto;
        }

        public async Task<ApplicationResponse<AddUserDiaryResponse>> Handle(AddUserDiaryCommand addUserDiaryCommand, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByIdAsync(addUserDiaryCommand.UserId, cancellationToken);
            if (user is null) return ApplicationResponse<AddUserDiaryResponse>.Fail(UserMessages.UserNotFound);

            string encryptedContent = _userDiaryCrypto.EncryptDiary(
                addUserDiaryCommand.Content,
                user.EncryptedDek,
                user.UserCode,
                user.Salt);


            UserDiary newUserDiary = new UserDiary
            {
                UserId = addUserDiaryCommand.UserId,
                Content = encryptedContent,
                Feel = addUserDiaryCommand.Feel,
                DiaryTag = addUserDiaryCommand.DiaryTag,
                CreatedDate = DateTime.UtcNow,
            };

            UserDiary addedUserDiary = await _userDiaryRepository.AddUserDiaryAsync(newUserDiary, cancellationToken);

            AddUserDiaryResponse addUserDiaryResponse = new AddUserDiaryResponse
            {
                Id = addedUserDiary.Id,
                UserId = addedUserDiary.UserId,
                Content = addedUserDiary.Content,
                Feel = addedUserDiary.Feel,
                DiaryTag = addedUserDiary.DiaryTag,
                CreatedDate = addedUserDiary.CreatedDate
            };

            return new ApplicationResponse<AddUserDiaryResponse>
            {
                Data = addUserDiaryResponse,
                Message = UserDiaryMessages.AddUserDiarySuccess,
                Success = true
            };
        }
    }
}
