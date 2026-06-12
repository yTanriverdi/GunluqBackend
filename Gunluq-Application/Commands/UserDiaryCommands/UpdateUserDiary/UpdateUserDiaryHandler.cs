using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunluq_Application.Commands.UserDiaryCommands.UpdateUserDiary
{
    public class UpdateUserDiaryHandler : IRequestHandler<UpdateUserDiaryCommand, ApplicationResponse<UpdateUserDiaryResponse>>
    {
        private readonly IUserDiaryRepository _userDiaryRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserDiaryCrypto _userCrypto;

        public UpdateUserDiaryHandler(IUserDiaryRepository userDiaryRepository, IUserRepository userRepository, UserDiaryCrypto userCrypto)
        {
            _userDiaryRepository = userDiaryRepository;
            _userRepository = userRepository;
            _userCrypto = userCrypto;
        }

        public async Task<ApplicationResponse<UpdateUserDiaryResponse>> Handle(UpdateUserDiaryCommand updateUserDiaryCommand, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByIdAsync(updateUserDiaryCommand.UserId, cancellationToken);
            if (user is null) return ApplicationResponse<UpdateUserDiaryResponse>.Fail(UserMessages.UserNotFound);

            UserDiary? userDiary = await _userDiaryRepository.GetUserDiaryByIdAsync(updateUserDiaryCommand.UserDiaryId, cancellationToken);
            if (userDiary is null) return ApplicationResponse<UpdateUserDiaryResponse>.Fail(UserDiaryMessages.UserDiaryNotFound);

            userDiary.UpdatedDate = DateTime.UtcNow;
            userDiary.Feel = updateUserDiaryCommand.Feel;
            userDiary.DiaryTag = updateUserDiaryCommand.DiaryTag;

            string crypto = _userCrypto.EncryptDiary(updateUserDiaryCommand.Content, user.EncryptedDek, user.UserCode, user.Salt);

            userDiary.Content = crypto;
            UserDiary updatedUserDiary = await _userDiaryRepository.UpdateUserDiaryAsync(userDiary, cancellationToken);

            UpdateUserDiaryResponse updateUserDiaryResponse = new UpdateUserDiaryResponse
            {
                Id = updatedUserDiary.Id,
                UserId = updatedUserDiary.UserId,
                Content = updateUserDiaryCommand.Content,
                DiaryTag = updateUserDiaryCommand.DiaryTag,
                Feel = updateUserDiaryCommand.Feel,
                CreatedDate = updatedUserDiary.CreatedDate,
                UpdatedDate = updatedUserDiary.UpdatedDate
            };

            return new ApplicationResponse<UpdateUserDiaryResponse>
            {
                Data = updateUserDiaryResponse,
                Message = UserDiaryMessages.UserDiaryUpdateSuccess,
                Success = true
            };
         }
    }
}
