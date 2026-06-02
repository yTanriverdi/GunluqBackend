using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.PasswordHelper;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, ApplicationResponse<AddUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserDiaryCrypto _userDiaryCrypto;

        public AddUserHandler(IUserRepository userRepository, UserDiaryCrypto userDiaryCrypto)
        {
            _userRepository = userRepository;
            _userDiaryCrypto = userDiaryCrypto;
        }

        public async Task<ApplicationResponse<AddUserResponse>> Handle(AddUserCommand addUserCommand, CancellationToken cancellationToken)
        {
            User? anyUser = await _userRepository.GetUserByEmailAsync(addUserCommand.Email, cancellationToken);
            if (anyUser is not null) return ApplicationResponse<AddUserResponse>.Fail(UserMessages.UserAlreadyExists);
            
            var crypto = _userDiaryCrypto.CreateUserCrypto();

            User newUser = new User
                {
                    Email = addUserCommand.Email,
                    UserName = addUserCommand.UserName,
                    FirstName = addUserCommand.FirstName,
                    LastName = addUserCommand.LastName,
                    Password = PasswordHasher.Hash(addUserCommand.Password),
                    UserCode = crypto.userCode,
                    Salt = crypto.salt,
                    EncryptedDek = crypto.encryptedDek
            };
            User addedUser = await _userRepository.AddUserAsync(newUser, cancellationToken);
            AddUserResponse newUserResponse = new AddUserResponse
            {
                Email = addedUser.Email,
                UserName = addedUser.UserName,
                FirstName = addedUser.FirstName,
                LastName = addedUser.LastName,
                CreatedDate = addedUser.CreatedDate
            };
            return ApplicationResponse<AddUserResponse>.Ok(newUserResponse, UserMessages.UserAddSuccess);
        }
    }
}
