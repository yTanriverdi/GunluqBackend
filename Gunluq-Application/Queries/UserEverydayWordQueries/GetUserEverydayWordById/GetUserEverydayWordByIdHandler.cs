using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetUserEverydayWordById
{
    public class GetUserEverydayWordByIdHandler : IRequestHandler<GetUserEverydayWordByIdQuery, ApplicationResponse<GetUserEverydayWordByIdResponse>>
    {
        private readonly IUserEverydayWordRepository _userEverydayWordRepository;
        private readonly IUserRepository _userRepository;

        public GetUserEverydayWordByIdHandler(IUserEverydayWordRepository userEverydayWordRepository, IUserRepository userRepository)
        {
            _userEverydayWordRepository = userEverydayWordRepository;
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<GetUserEverydayWordByIdResponse>> Handle(GetUserEverydayWordByIdQuery getUserEverydayWordByIdQuery, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(getUserEverydayWordByIdQuery.UserId, cancellationToken);
            if(foundUser is null) return ApplicationResponse<GetUserEverydayWordByIdResponse>.Fail(UserMessages.UserNotFound);

            UserEverydayWord? userEverydayWord = await _userEverydayWordRepository.GetUserEverydayWordByIdAsync(getUserEverydayWordByIdQuery.UserEverydayWordId, cancellationToken);
            if(userEverydayWord is null || foundUser.Id != userEverydayWord.UserId) return ApplicationResponse<GetUserEverydayWordByIdResponse>.Fail(UserEverydayWordMessages.UserEverydayWordNotFound);

            return ApplicationResponse<GetUserEverydayWordByIdResponse>.Ok(new GetUserEverydayWordByIdResponse
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
