using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ApplicationResponse<UpdateUserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<UpdateUserResponse>> Handle(UpdateUserCommand updateUserCommand, CancellationToken cancellationToken)
        {
            User? anyUser = await _userRepository.GetUserByIdAsync(updateUserCommand.UserId, cancellationToken);
            if (anyUser is null)
                return ApplicationResponse<UpdateUserResponse>.Fail(UserMessages.UserNotFound);

            anyUser.Email = updateUserCommand.Email;
            anyUser.UserName = updateUserCommand.UserName;
            anyUser.FirstName = updateUserCommand.FirstName;
            anyUser.LastName = updateUserCommand.LastName;
            anyUser.UpdatedDate = DateTime.UtcNow;

            User userUpdateRes = await _userRepository.UpdateUserAsync(anyUser, cancellationToken);

            UpdateUserResponse updateUserResponse = new UpdateUserResponse
            {
                Email = userUpdateRes.Email,
                UserName = userUpdateRes.UserName,
                FirstName = userUpdateRes.FirstName,
                LastName = userUpdateRes.LastName,
                UpdatedDate = userUpdateRes.UpdatedDate
            };
            return ApplicationResponse<UpdateUserResponse>.Ok(updateUserResponse, UserMessages.UserUpdateSuccess);
        }
    }
}
