using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserEverydayWordCommands.UpdateEverydayWord
{
    public class UpdateUserEverydayWordHandler : IRequestHandler<UpdateUserEverydayWordCommand, ApplicationResponse<UpdateUserEverydayWordResponse>>
    {
        private readonly IUserEverydayWordRepository _userEverydayWordRepository;
        private readonly IUserRepository _userRepository;

        public UpdateUserEverydayWordHandler(IUserEverydayWordRepository userEverydayWordRepository, IUserRepository userRepository)
        {
            _userEverydayWordRepository = userEverydayWordRepository;
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<UpdateUserEverydayWordResponse>> Handle(UpdateUserEverydayWordCommand updateUserEverydayWordCommand, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(updateUserEverydayWordCommand.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<UpdateUserEverydayWordResponse>.Fail(UserMessages.UserNotFound);

            UserEverydayWord? userEverydayWord = await _userEverydayWordRepository.GetUserEverydayWordByIdAsync(updateUserEverydayWordCommand.UserEverydayWordId, cancellationToken);
            if(userEverydayWord is null || userEverydayWord.UserId != foundUser.Id) return ApplicationResponse<UpdateUserEverydayWordResponse>.Fail(UserEverydayWordMessages.UserEverydayWordNotFound);

            userEverydayWord.Content = updateUserEverydayWordCommand.Content;

            UserEverydayWord updatedUserEverydayWord = await _userEverydayWordRepository.UpdateEverydayWordAsync(userEverydayWord, cancellationToken);

            return ApplicationResponse<UpdateUserEverydayWordResponse>.Ok(new UpdateUserEverydayWordResponse { Id = updatedUserEverydayWord.Id, Content = updatedUserEverydayWord.Content, UpdatedDate = updatedUserEverydayWord.UpdatedDate }, UserEverydayWordMessages.UserEverydayWordUpdateSuccess);
        }
    }
}
