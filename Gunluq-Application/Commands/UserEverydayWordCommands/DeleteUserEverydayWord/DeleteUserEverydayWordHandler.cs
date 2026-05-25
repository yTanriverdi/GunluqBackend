using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserEverydayWordCommands.DeleteUserEverydayWord
{
    public class DeleteUserEverydayWordHandler : IRequestHandler<DeleteUserEverydayWordCommand, ApplicationResponse<DeleteUserEverydayWordResponse>>
    {
        private readonly IUserEverydayWordRepository _userEverydayWordRepository;
        private readonly IUserRepository _userRepository;

        public DeleteUserEverydayWordHandler(IUserEverydayWordRepository userEverydayWordRepository, IUserRepository userRepository)
        {
            _userEverydayWordRepository = userEverydayWordRepository;
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<DeleteUserEverydayWordResponse>> Handle(DeleteUserEverydayWordCommand deleteUserEverydayWordCommand, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(deleteUserEverydayWordCommand.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<DeleteUserEverydayWordResponse>.Fail(UserMessages.UserNotFound);

            UserEverydayWord? deletingUserEverydayWord = await _userEverydayWordRepository.GetUserEverydayWordByIdAsync(deleteUserEverydayWordCommand.UserEverydayWordId, cancellationToken);

            if (deleteUserEverydayWordCommand is null || deletingUserEverydayWord?.UserId != foundUser.Id) return ApplicationResponse<DeleteUserEverydayWordResponse>.Fail(UserEverydayWordMessages.UserEverydayWordNotFound);

            bool deleteUserEverydayWordResult = await _userEverydayWordRepository.DeleteEverydayWordAsync(deletingUserEverydayWord.Id, cancellationToken);
            if (!deleteUserEverydayWordResult) return ApplicationResponse<DeleteUserEverydayWordResponse>.Fail(UserEverydayWordMessages.UserEverydayWordDeleteFail);

            return ApplicationResponse<DeleteUserEverydayWordResponse>.Ok( new DeleteUserEverydayWordResponse { Success = true }, UserEverydayWordMessages.UserEverydayWordDeleteSuccess);
        }
    }
}
