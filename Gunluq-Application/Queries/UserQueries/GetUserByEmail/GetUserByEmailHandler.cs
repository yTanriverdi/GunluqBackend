using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserQueries.GetUserByEmail
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, ApplicationResponse<GetUserByEmailResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<GetUserByEmailResponse>> Handle(GetUserByEmailQuery getUserByEmailQuery, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByEmailAsync(getUserByEmailQuery.Email, cancellationToken);
            if (user is null) return ApplicationResponse<GetUserByEmailResponse>.Fail(UserMessages.UserNotFound);
            GetUserByEmailResponse getUserByEmailResponse = new GetUserByEmailResponse
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
                DeletedDate = user.DeletedDate,
                UserDiaries = user.UserDiaries?.ToList(),
                UserEverydayWords = user.UserEverydayWords?.ToList(),
                UserNotes = user.UserNotes?.ToList(),
                Status = user.Status
            };
            return ApplicationResponse<GetUserByEmailResponse>.Ok(getUserByEmailResponse, UserMessages.UserFound);
        }
    }
}
