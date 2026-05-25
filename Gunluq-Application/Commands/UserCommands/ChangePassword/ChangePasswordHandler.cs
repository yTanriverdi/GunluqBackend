using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.PasswordHelper;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.ChangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, ApplicationResponse<ChangePasswordResponse>>
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<ChangePasswordResponse>> Handle(ChangePasswordCommand changePasswordCommand, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByIdAsync(changePasswordCommand.UserId, cancellationToken);
            if (user is null)
                return ApplicationResponse<ChangePasswordResponse>
                    .Fail(UserMessages.UserNotFound);

            bool isValid = PasswordHasher.VerifyPassword(changePasswordCommand.NewPassword, changePasswordCommand.OldPassword);

            if (!isValid)
                return ApplicationResponse<ChangePasswordResponse>
                    .Fail(UserMessages.WrongPassword);

            string newHashedPassword = PasswordHasher.Hash(changePasswordCommand.NewPassword);

            bool updated = await _userRepository.UserPasswordUpdateAsync(
                changePasswordCommand.UserId,
                newHashedPassword,
                cancellationToken);

            if (!updated)
                return ApplicationResponse<ChangePasswordResponse>
                    .Fail(UserMessages.FailPasswordChange);

            return ApplicationResponse<ChangePasswordResponse>.Ok(
                new ChangePasswordResponse { Success = true },
                UserMessages.SuccessPasswordChange);
        }
    }
}
