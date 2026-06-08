using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.PasswordHelper;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.DTOs;
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
            LoginUserInfo? foundUser = await _userRepository.GetForLoginUserAsync(loginUserCommand.Email, cancellationToken);
            if(foundUser?.User is null) return ApplicationResponse<LoginUserResponse>.Fail(UserMessages.WrongEmailOrPassword);
            else
            {
                bool hashedPassword = PasswordHasher.VerifyPassword(foundUser.User.Password, loginUserCommand.Password); 
                if(!hashedPassword) return ApplicationResponse<LoginUserResponse>.Fail(UserMessages.WrongEmailOrPassword);
                return ApplicationResponse<LoginUserResponse>.Ok(new LoginUserResponse
                {
                    UserId = foundUser.User.Id,
                    Email = foundUser.User.Email,
                    FirstName = foundUser.User.FirstName,
                    LastName = foundUser.User.LastName,
                    UserName = foundUser.User.UserName,
                    Role = foundUser.User.Role,
                    CreatedDate = foundUser.User.CreatedDate,
                    UpdatedDate = foundUser.User.UpdatedDate,
                    DiaryCount = foundUser.DiaryCount,
                    EverydayWordCount = foundUser.EverydayWordCount,
                    NoteCount = foundUser.NoteCount
                }, UserMessages.LoginAccess);
            }
        }
    }
}
