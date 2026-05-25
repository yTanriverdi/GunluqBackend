using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ApplicationResponse<List<GetAllUsersResponse>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApplicationResponse<List<GetAllUsersResponse>>> Handle(GetAllUsersQuery getAllUsersQuery, CancellationToken cancellationToken)
        {
            List<User>? foundUsers = await _userRepository.GetAllUsersAsync(cancellationToken);

            if (!foundUsers.Any()) return ApplicationResponse<List<GetAllUsersResponse>>.Fail(UserMessages.UsersCountZero);
            List<GetAllUsersResponse> responseUsers = foundUsers.Select(x => new GetAllUsersResponse
            {
                Id = x.Id,
                Email = x.Email,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsBanned = x.IsBanned,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                UserDiaries = x.UserDiaries?.ToList(),
                UserEverydayWords = x.UserEverydayWords?.ToList(),
                UserNotes = x.UserNotes?.ToList(),
                Status = x.Status
            }).ToList();
            return new ApplicationResponse<List<GetAllUsersResponse>>
            {
                Data = responseUsers,
                Message = UserMessages.UsersFound,
                Success = true
            };
        }
    }
}
