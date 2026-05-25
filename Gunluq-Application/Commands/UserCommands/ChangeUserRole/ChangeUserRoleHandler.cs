using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Commands.UserCommands.ChangeUserRole
{
    public class ChangeUserRoleHandler : IRequestHandler<ChangeUserRoleCommand, ApplicationResponse<ChangeUserRoleResponse>>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserRoleHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<ChangeUserRoleResponse>> Handle(ChangeUserRoleCommand changeUserRoleCommand, CancellationToken cancellationToken)
        {
            User? anyUser = await _userRepository.GetUserByIdAsync(changeUserRoleCommand.UserId, cancellationToken);
            if (anyUser is null) return ApplicationResponse<ChangeUserRoleResponse>.Fail(UserMessages.UserNotFound);
            bool changeRoleRes = await _userRepository.ChangeUserRoleAsync(changeUserRoleCommand.UserId, cancellationToken);
            if(!changeRoleRes) return ApplicationResponse<ChangeUserRoleResponse>.Fail(UserMessages.UpdateRoleFail);
            ChangeUserRoleResponse changeUserRoleResponse = new ChangeUserRoleResponse { Success = true };
            return ApplicationResponse<ChangeUserRoleResponse>.Ok(changeUserRoleResponse, UserMessages.UpdateRoleSuccess);
        }
    }
}
