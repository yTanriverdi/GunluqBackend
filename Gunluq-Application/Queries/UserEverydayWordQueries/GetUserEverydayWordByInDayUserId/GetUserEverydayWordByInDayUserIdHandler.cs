using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetUserEverydayWordByInDayUserId
{
    public class GetUserEverydayWordByInDayUserIdHandler : IRequestHandler<GetUserEverydayWordByInDayUserIdQuery, ApplicationResponse<GetUserEverydayWordByInDayUserIdResponse>>
    {
        private readonly IUserEverydayWordRepository _userEverydayWordRepository;
        private readonly IUserRepository _userRepository;

        public GetUserEverydayWordByInDayUserIdHandler(IUserEverydayWordRepository userEverydayWordRepository, IUserRepository userRepository)
        {
            _userEverydayWordRepository = userEverydayWordRepository;
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<GetUserEverydayWordByInDayUserIdResponse>> Handle(GetUserEverydayWordByInDayUserIdQuery getUserEverydayWordByInDayUserIdQuery, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(getUserEverydayWordByInDayUserIdQuery.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<GetUserEverydayWordByInDayUserIdResponse>.Fail(UserMessages.UserNotFound);

            UserEverydayWord? userEverydayWord = await _userEverydayWordRepository.GetUserEverydayWordByInDayUserIdAsync(getUserEverydayWordByInDayUserIdQuery.UserId, cancellationToken);
            if (userEverydayWord is null || foundUser.Id != userEverydayWord.UserId) return ApplicationResponse<GetUserEverydayWordByInDayUserIdResponse>.Fail(UserEverydayWordMessages.UserEverydayWordNotFound);

            return ApplicationResponse<GetUserEverydayWordByInDayUserIdResponse>.Ok(new GetUserEverydayWordByInDayUserIdResponse
            {
                Id = userEverydayWord.Id,
                UserId = userEverydayWord.UserId,
                Content = userEverydayWord.Content,
                CreatedDate = userEverydayWord.CreatedDate,
                UpdatedDate = userEverydayWord.UpdatedDate,
                DeletedDate = userEverydayWord.DeletedDate,
                Status = userEverydayWord.Status
            }, UserEverydayWordMessages.UserEverydayWordFound);
        }
    }
}
