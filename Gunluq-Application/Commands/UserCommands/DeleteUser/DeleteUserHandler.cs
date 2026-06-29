using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.PasswordHelper;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ApplicationResponse<DeleteUserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<DeleteUserResponse>> Handle(DeleteUserCommand deleteUserCommand, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(deleteUserCommand.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<DeleteUserResponse>.Fail(UserMessages.UserNotFound);
            var password = PasswordHasher.VerifyPassword(foundUser.Password, deleteUserCommand.Password);
            if (!password) return ApplicationResponse<DeleteUserResponse>.Fail(UserMessages.WrongPassword);
            bool deleteUserResult = await _userRepository.DeleteUserAsync(deleteUserCommand.UserId, cancellationToken);
            if(!deleteUserResult) return ApplicationResponse<DeleteUserResponse>.Fail(UserMessages.UserDeleteFail);
            return new ApplicationResponse<DeleteUserResponse>
            {
                Data = new DeleteUserResponse
                {
                    Id = deleteUserCommand.UserId,
                    IsDeleted = true,
                    DeletedDate = DateTime.UtcNow,
                },
                Message = UserMessages.UserDeleteSuccess,
                Success = true
            };
        }
    }
}
