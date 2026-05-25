using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetUserDiaryById
{
    public class GetUserDiaryByIdHandler : IRequestHandler<GetUserDiaryByIdQuery, ApplicationResponse<GetUserDiaryByIdResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDiaryRepository _userDiaryRepository;
        private readonly UserDiaryCrypto _userDiaryCrypto;

        public GetUserDiaryByIdHandler(IUserRepository userRepository, IUserDiaryRepository userDiaryRepository, UserDiaryCrypto userDiaryCrypto)
        {
            _userRepository = userRepository;
            _userDiaryRepository = userDiaryRepository;
            _userDiaryCrypto = userDiaryCrypto;
        }

        public async Task<ApplicationResponse<GetUserDiaryByIdResponse>> Handle(GetUserDiaryByIdQuery getUserDiaryByIdQuery, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByIdAsync(getUserDiaryByIdQuery.UserId, cancellationToken);
            if(user is null) return ApplicationResponse<GetUserDiaryByIdResponse>.Fail(UserMessages.UserNotFound);
            
            UserDiary? userDiary = await _userDiaryRepository.GetUserDiaryByIdAsync(getUserDiaryByIdQuery.UserDiaryId, cancellationToken);
            if(userDiary is null) return ApplicationResponse<GetUserDiaryByIdResponse>.Fail(UserDiaryMessages.UserDiaryNotFound);

            GetUserDiaryByIdResponse getUserDiaryByIdResponse = new GetUserDiaryByIdResponse
            {
                Id = userDiary.Id,
                UserId = userDiary.UserId,
                Content = _userDiaryCrypto.DecryptDiary(userDiary.Content, user.EncryptedDek, user.UserCode, user.Salt),
                DiaryTag = userDiary.DiaryTag,
                Feel = userDiary.Feel,
                CreatedDate = userDiary.CreatedDate,
                UpdatedDate = userDiary.UpdatedDate,
                DeletedDate = userDiary.DeletedDate,
                Status = userDiary.Status
            };
            return new ApplicationResponse<GetUserDiaryByIdResponse> { Data = getUserDiaryByIdResponse, Message = UserDiaryMessages.UserDiaryFound, Success = true };

        }
    }
}
