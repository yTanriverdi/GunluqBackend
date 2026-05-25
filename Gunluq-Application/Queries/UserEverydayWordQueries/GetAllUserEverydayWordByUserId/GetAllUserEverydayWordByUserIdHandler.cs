using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetAllUserEverydayWordByUserId
{
    public class GetAllUserEverydayWordByUserIdHandler : IRequestHandler<GetAllUserEverydayWordByUserIdQuery, ApplicationResponse<List<GetAllUserEverydayWordByUserIdResponse>>>
    {
        private readonly IUserEverydayWordRepository _userEverydayWordRepository;
        private readonly IUserRepository _userRepository;

        public GetAllUserEverydayWordByUserIdHandler(IUserEverydayWordRepository userEverydayWordRepository, IUserRepository userRepository)
        {
            _userEverydayWordRepository = userEverydayWordRepository;
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<List<GetAllUserEverydayWordByUserIdResponse>>> Handle(GetAllUserEverydayWordByUserIdQuery getAllUserEverydayWordByUserIdQuery, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(getAllUserEverydayWordByUserIdQuery.UserId, cancellationToken);
            if(foundUser is null) return ApplicationResponse<List<GetAllUserEverydayWordByUserIdResponse>>.Fail(UserMessages.UserNotFound);

            List<UserEverydayWord> userEverydayWords = await _userEverydayWordRepository.GetAllUserEverydayWordByUserIdAsync(getAllUserEverydayWordByUserIdQuery.UserId, cancellationToken);
            if (!userEverydayWords.Any()) return ApplicationResponse<List<GetAllUserEverydayWordByUserIdResponse>>.Fail(UserEverydayWordMessages.UserEverydayWordsNotFound);

            List<GetAllUserEverydayWordByUserIdResponse> getAllUserEverydayWordByUserIdResponses = userEverydayWords.Select(x => new GetAllUserEverydayWordByUserIdResponse 
            { 
                Id = x.Id,
                UserId = x.UserId,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                Status = x.Status
            }).ToList();

            return ApplicationResponse<List<GetAllUserEverydayWordByUserIdResponse>>.Ok(getAllUserEverydayWordByUserIdResponses, UserEverydayWordMessages.UserEverydayWordsFound);
        }
    }
}
