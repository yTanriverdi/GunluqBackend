using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserQueries.GetUserByUserName
{
    public class GetUserByUserNameHandler : IRequestHandler<GetUserByUserNameQuery, ApplicationResponse<GetUserByUserNameResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUserNameHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<GetUserByUserNameResponse>> Handle(GetUserByUserNameQuery getUserByUserNameQuery, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByUserNameAsync(getUserByUserNameQuery.UserName, cancellationToken);
            if (user is null) return ApplicationResponse<GetUserByUserNameResponse>.Fail(UserMessages.UserNotFound);
            GetUserByUserNameResponse getUserByUserNameResponse = new GetUserByUserNameResponse
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsBanned = user.IsBanned,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
                DeletedDate = user.DeletedDate,
                UserDiaries = user.UserDiaries.ToList(),
                UserNotes = user.UserNotes.ToList(),
                UserEverydayWords = user.UserEverydayWords.ToList(),
                Status = user.Status
            };
            return ApplicationResponse<GetUserByUserNameResponse>.Ok(getUserByUserNameResponse, UserMessages.UserFound);
        }
    }
}
