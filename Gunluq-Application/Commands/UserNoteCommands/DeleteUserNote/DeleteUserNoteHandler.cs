using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserNoteCommands.DeleteUserNote
{
    public class DeleteUserNoteHandler : IRequestHandler<DeleteUserNoteCommand, ApplicationResponse<DeleteUserNoteResponse>>
    {
        private readonly IUserNoteRepository _userNoteRepository;
        private readonly IUserRepository _userRepository;

        public DeleteUserNoteHandler(IUserNoteRepository userNoteRepository, IUserRepository userRepository)
        {
            _userNoteRepository = userNoteRepository;
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<DeleteUserNoteResponse>> Handle(DeleteUserNoteCommand deleteUserNoteCommand, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(deleteUserNoteCommand.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<DeleteUserNoteResponse>.Fail(UserMessages.UserNotFound);

            UserNote? forDeleteUserNote = await _userNoteRepository.GetUserNoteByIdAsync(deleteUserNoteCommand.UserNoteId, cancellationToken);
            if(forDeleteUserNote is null || forDeleteUserNote.UserId != foundUser.Id) return ApplicationResponse<DeleteUserNoteResponse>.Fail(UserNoteMessages.UserNoteNotFound);

            bool deleteResult = await _userNoteRepository.DeleteUserNoteByIdAsync(deleteUserNoteCommand.UserNoteId, cancellationToken);
            if (!deleteResult) return ApplicationResponse<DeleteUserNoteResponse>.Fail(UserNoteMessages.UserNoteDeleteFail);
            return ApplicationResponse<DeleteUserNoteResponse>.Ok(new DeleteUserNoteResponse
            {
                Success = true
            }, UserNoteMessages.UserNoteDeleteSuccess);
        }
    }
}
