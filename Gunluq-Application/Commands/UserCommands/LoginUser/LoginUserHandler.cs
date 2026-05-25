using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.PasswordHelper;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, ApplicationResponse<LoginUserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<LoginUserResponse>> Handle(LoginUserCommand loginUserCommand, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByEmailAsync(loginUserCommand.Email, cancellationToken);
            if(foundUser is null) return ApplicationResponse<LoginUserResponse>.Fail(UserMessages.WrongEmailOrPassword);
            else
            {
                bool hashedPassword = PasswordHasher.VerifyPassword(foundUser.Password, loginUserCommand.Password);
                if(!hashedPassword) return ApplicationResponse<LoginUserResponse>.Fail(UserMessages.WrongEmailOrPassword);
                return ApplicationResponse<LoginUserResponse>.Ok(new LoginUserResponse
                {
                    UserId = foundUser.Id,
                    Email = foundUser.Email,
                    FirstName = foundUser.FirstName,
                    LastName = foundUser.LastName,
                    UserName = foundUser.UserName,
                    Role = foundUser.Role,
                    CreatedDate = foundUser.CreatedDate,
                    UpdatedDate = foundUser.UpdatedDate
                }, UserMessages.LoginAccess);
            }
        }
    }
}
