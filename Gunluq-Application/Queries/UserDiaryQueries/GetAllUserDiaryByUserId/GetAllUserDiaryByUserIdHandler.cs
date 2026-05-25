using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByUserId
{
    public class GetAllUserDiaryByUserIdHandler : IRequestHandler<GetAllUserDiaryByUserIdQuery, ApplicationResponse<List<GetAllUserDiaryByUserIdResponse>>>
    {
        private readonly IUserDiaryRepository _userDiaryRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserDiaryCrypto _userDiaryCrypto;

        public GetAllUserDiaryByUserIdHandler(IUserDiaryRepository userDiaryRepository, IUserRepository userRepository, UserDiaryCrypto userDiaryCrypto)
        {
            _userDiaryRepository = userDiaryRepository;
            _userRepository = userRepository;
            _userDiaryCrypto = userDiaryCrypto;
        }

        public async Task<ApplicationResponse<List<GetAllUserDiaryByUserIdResponse>>> Handle(GetAllUserDiaryByUserIdQuery getAllUserDiaryByUserIdQuery, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(getAllUserDiaryByUserIdQuery.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<List<GetAllUserDiaryByUserIdResponse>>.Fail(UserMessages.UserNotFound);
            List<UserDiary> userDiaries = await _userDiaryRepository.GetAllUserDiaryByUserIdAsync(getAllUserDiaryByUserIdQuery.UserId, cancellationToken);
            if (!userDiaries.Any()) return ApplicationResponse<List<GetAllUserDiaryByUserIdResponse>>.Fail(UserDiaryMessages.UserDiariesNotFound);

            List<GetAllUserDiaryByUserIdResponse> getAllUserDiaryByUserIdResponses = userDiaries.Select(x => new GetAllUserDiaryByUserIdResponse
            {
                Id = x!.Id,
                UserId = x.UserId,
                Content = _userDiaryCrypto.DecryptDiary(x.Content, foundUser.EncryptedDek, foundUser.UserCode, foundUser.Salt), 
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                DiaryTag = x.DiaryTag,
                Feel = x.Feel,
                Status = x.Status
            }).ToList();

            return ApplicationResponse<List<GetAllUserDiaryByUserIdResponse>>.Ok(getAllUserDiaryByUserIdResponses, UserDiaryMessages.UserDiariesFound);
        }
    }
}
