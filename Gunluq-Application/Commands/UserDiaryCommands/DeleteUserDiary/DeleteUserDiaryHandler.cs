using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserDiaryCommands.DeleteUserDiary
{
    public class DeleteUserDiaryHandler : IRequestHandler<DeleteUserDiaryCommand, ApplicationResponse<DeleteUserDiaryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDiaryRepository _userDiaryRepository;

        public DeleteUserDiaryHandler(IUserRepository userRepository, IUserDiaryRepository userDiaryRepository)
        {
            _userRepository = userRepository;
            _userDiaryRepository = userDiaryRepository;
        }

        public async Task<ApplicationResponse<DeleteUserDiaryResponse>> Handle(DeleteUserDiaryCommand deleteUserDiaryCommand, CancellationToken cancellationToken)
        {
            UserDiary? userDiary = await _userDiaryRepository.GetUserDiaryByIdAsync(deleteUserDiaryCommand.UserDiaryId, cancellationToken);
            if (userDiary is null) return ApplicationResponse<DeleteUserDiaryResponse>.Fail(UserDiaryMessages.UserDiaryNotFound);
            if (userDiary.UserId != deleteUserDiaryCommand.UserId) return ApplicationResponse<DeleteUserDiaryResponse>.Fail(UserDiaryMessages.UserDiaryDeleteFail);
            bool userDiaryDeleteResult = await _userDiaryRepository.DeleteAsync(deleteUserDiaryCommand.UserDiaryId, cancellationToken);
            if (!userDiaryDeleteResult) return ApplicationResponse<DeleteUserDiaryResponse>.Fail(UserDiaryMessages.UserDiaryDeleteFail);
            DeleteUserDiaryResponse deleteUserDiaryResponse = new DeleteUserDiaryResponse { Id = userDiary.Id , IsDeleted = true, DeletedDate = DateTime.UtcNow};
            return new ApplicationResponse<DeleteUserDiaryResponse>
            {
                Data = deleteUserDiaryResponse,
                Message = UserDiaryMessages.UserDiaryDeleteSuccess,
                Success = true
            };
        }
    }
}
