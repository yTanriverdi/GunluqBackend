using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserEverydayWordCommands.AddUserEverydayWord
{
    public class AddUserEverydayWordHandler : IRequestHandler<AddUserEverydayWordCommand, ApplicationResponse<AddUserEverydayWordResponse>>
    {
        private readonly IUserEverydayWordRepository _userEverydayWordRepository;
        private readonly IUserRepository _userRepository;

        public AddUserEverydayWordHandler(IUserEverydayWordRepository userEverydayWordRepository, IUserRepository userRepository)
        {
            _userEverydayWordRepository = userEverydayWordRepository;
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<AddUserEverydayWordResponse>> Handle(AddUserEverydayWordCommand addUserEverydayWordCommand, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(addUserEverydayWordCommand.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<AddUserEverydayWordResponse>.Fail(UserMessages.UserNotFound);

            UserEverydayWord userEverydayWord = new UserEverydayWord
            {
                UserId = addUserEverydayWordCommand.UserId,
                Content = addUserEverydayWordCommand.Content
            };

            UserEverydayWord addedUserEverydayWord = await _userEverydayWordRepository.AddUserEverydayWordAsync(userEverydayWord, cancellationToken);
            return ApplicationResponse<AddUserEverydayWordResponse>.Ok(new AddUserEverydayWordResponse { Id = addedUserEverydayWord.Id, Content = addedUserEverydayWord.Content , CreatedDate = addedUserEverydayWord.CreatedDate}, UserEverydayWordMessages.AddUserEverydayWordSuccess);
        }
    }
}
