using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ApplicationResponse<GetUserByIdResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<GetUserByIdResponse>> Handle(GetUserByIdQuery getUserByIdQuery, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByIdAsync(getUserByIdQuery.UserId, cancellationToken);
            if (user is null) return ApplicationResponse<GetUserByIdResponse>.Fail(UserMessages.UserNotFound);
            GetUserByIdResponse getUserByIdResponse = new GetUserByIdResponse
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
                UserDiaries = user.UserDiaries?.ToList(),
                UserEverydayWords = user.UserEverydayWords?.ToList(),
                UserNotes = user.UserNotes?.ToList(),
                Status = user.Status
            };
            return ApplicationResponse<GetUserByIdResponse>.Ok(getUserByIdResponse, UserMessages.UserFound);
        }
    }
}
