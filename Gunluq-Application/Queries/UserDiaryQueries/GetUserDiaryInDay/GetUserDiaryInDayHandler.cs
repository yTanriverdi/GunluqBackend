using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByUserId;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetUserDiaryInDay
{
    public class GetUserDiaryInDayHandler : IRequestHandler<GetUserDiaryInDayQuery, ApplicationResponse<GetUserDiaryInDayResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDiaryRepository _userDiaryRepository;
        private readonly UserDiaryCrypto _userDiaryCrypto;

        public GetUserDiaryInDayHandler(IUserRepository userRepository, IUserDiaryRepository userDiaryRepository, UserDiaryCrypto userDiaryCrypto)
        {
            _userRepository = userRepository;
            _userDiaryRepository = userDiaryRepository;
            _userDiaryCrypto = userDiaryCrypto;
        }
        public async Task<ApplicationResponse<GetUserDiaryInDayResponse>> Handle(GetUserDiaryInDayQuery getUserDiaryInDayQuery, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(getUserDiaryInDayQuery.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<GetUserDiaryInDayResponse>.Fail(UserMessages.UserNotFound);
            UserDiary? userDiary = await _userDiaryRepository.GetUserDiaryInDayAsync(getUserDiaryInDayQuery.UserId, cancellationToken);
            if (userDiary is null) return ApplicationResponse<GetUserDiaryInDayResponse>.Fail(UserDiaryMessages.UserDiaryNotFound);

            GetUserDiaryInDayResponse getUserDiaryInDayResponse = new GetUserDiaryInDayResponse
            {
                Id = userDiary!.Id,
                UserId = userDiary.UserId,
                Content = _userDiaryCrypto.DecryptDiary(userDiary.Content, foundUser.EncryptedDek, foundUser.UserCode, foundUser.Salt),
                CreatedDate = userDiary.CreatedDate,
                UpdatedDate = userDiary.UpdatedDate,
                DeletedDate = userDiary.DeletedDate,
                DiaryTag = userDiary.DiaryTag,
                Feel = userDiary.Feel,
                Status = userDiary.Status
            };

            return ApplicationResponse<GetUserDiaryInDayResponse>.Ok(getUserDiaryInDayResponse, UserDiaryMessages.UserDiaryFound);
        }
    }
}
