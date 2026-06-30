using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Commands.UserCommands.AddUser;
using Gunluq_Application.Commands.UserCommands.ChangePassword;
using Gunluq_Application.Commands.UserCommands.ChangeUserRole;
using Gunluq_Application.Commands.UserCommands.DeleteUser;
using Gunluq_Application.Commands.UserCommands.LoginUser;
using Gunluq_Application.Commands.UserCommands.UpdateUser;
using Gunluq_Application.Queries.UserDiaryQueries.GetAnalysis;
using Gunluq_Application.Queries.UserQueries.GetAllUsers;
using Gunluq_Application.Queries.UserQueries.GetUserByEmail;
using Gunluq_Application.Queries.UserQueries.GetUserById;
using Gunluq_Application.Queries.UserQueries.GetUserByUserName;
using Gunluq_WebAPI.JWT;
using Gunluq_WebAPI.ResponseApi;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunluq_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand addUserCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<AddUserResponse> addUserResponse = await _mediator.Send(addUserCommand, cancellationToken);
            if (!addUserResponse.Success) return BadRequest(ApiResponse.FailResponse(addUserResponse.Message, 400));
            return Ok(ApiResponse<AddUserResponse>.SuccessResponse(addUserResponse.Data!, addUserResponse.Message, 201));
        }


        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand loginUserCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<LoginUserResponse> loginUserResponse = await _mediator.Send(loginUserCommand, cancellationToken);
            if (!loginUserResponse.Success) return BadRequest(ApiResponse.FailResponse(loginUserResponse.Message, 400));
            string jwtToken = JwtService.GenerateToken(loginUserResponse.Data!.UserId.ToString(), loginUserResponse.Data!.UserName, loginUserResponse.Data!.Email, loginUserResponse.Data!.Role.ToString());
            loginUserResponse.Data.JwtToken = jwtToken;
            return Ok(ApiResponse<LoginUserResponse>.SuccessResponse(loginUserResponse.Data!, loginUserResponse.Message, 200));
        }


        [Authorize(Policy = "UserOrAdmin")]
        [HttpPut("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand deleteUserCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<DeleteUserResponse> deleteUserResponse = await _mediator.Send(deleteUserCommand, cancellationToken);
            if (!deleteUserResponse.Success) return BadRequest(ApiResponse.FailResponse(deleteUserResponse.Message, 400));
            return Ok(ApiResponse<DeleteUserResponse>.SuccessResponse(deleteUserResponse.Data!, deleteUserResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changePasswordCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<ChangePasswordResponse> changePasswordResponse = await _mediator.Send(changePasswordCommand, cancellationToken);
            if (!changePasswordResponse.Success) return BadRequest(ApiResponse.FailResponse(changePasswordResponse.Message, 400));
            return Ok(ApiResponse<ChangePasswordResponse>.SuccessResponse(changePasswordResponse.Data!, changePasswordResponse.Message, 200));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("ChangeUserRole")]
        public async Task<IActionResult> ChangeUserRole([FromBody] ChangeUserRoleCommand changeUserRoleCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<ChangeUserRoleResponse> changeUserRoleResponse = await _mediator.Send(changeUserRoleCommand, cancellationToken);
            if (!changeUserRoleResponse.Success) return BadRequest(ApiResponse.FailResponse(changeUserRoleResponse.Message, 400));
            return Ok(ApiResponse<ChangeUserRoleResponse>.SuccessResponse(changeUserRoleResponse.Data!, changeUserRoleResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPut("UserUpdate")]
        public async Task<IActionResult> UserUpdate([FromBody] UpdateUserCommand updateUserCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<UpdateUserResponse> updateUserResponse = await _mediator.Send(updateUserCommand, cancellationToken);
            if (!updateUserResponse.Success) return BadRequest(ApiResponse.FailResponse(updateUserResponse.Message, 400));
            return Ok(ApiResponse<UpdateUserResponse>.SuccessResponse(updateUserResponse.Data!, updateUserResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUsersResponse>> getAllUsersResponse = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
            if (!getAllUsersResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUsersResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUsersResponse>>.SuccessResponse(getAllUsersResponse.Data!, getAllUsersResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] GetUserByEmailQuery getUserByEmailQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<GetUserByEmailResponse> getUserByEmailResponse = await _mediator.Send(getUserByEmailQuery, cancellationToken);
            if (!getUserByEmailResponse.Success) return BadRequest(ApiResponse.FailResponse(getUserByEmailResponse.Message, 400));
            return Ok(ApiResponse<GetUserByEmailResponse>.SuccessResponse(getUserByEmailResponse.Data!, getUserByEmailResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery getUserByIdQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<GetUserByIdResponse> getUserByIdResponse = await _mediator.Send(getUserByIdQuery, cancellationToken);
            if (!getUserByIdResponse.Success) return BadRequest(ApiResponse.FailResponse(getUserByIdResponse.Message, 400));
            return Ok(ApiResponse<GetUserByIdResponse>.SuccessResponse(getUserByIdResponse.Data!, getUserByIdResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetUserByUserName")]
        public async Task<IActionResult> GetUserByUserName([FromQuery] GetUserByUserNameQuery getUserByUserNameQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<GetUserByUserNameResponse> getUserByUserNameResponse = await _mediator.Send(getUserByUserNameQuery, cancellationToken);
            if (!getUserByUserNameResponse.Success) return BadRequest(ApiResponse.FailResponse(getUserByUserNameResponse.Message, 400));
            return Ok(ApiResponse<GetUserByUserNameResponse>.SuccessResponse(getUserByUserNameResponse.Data!, getUserByUserNameResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetUserAnalysis")]
        public async Task<IActionResult> GetUserAnalysis([FromQuery] GetAnalysisQuery getAnalysisQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<GetAnalysisResponse> getUserAnalysisResponse = await _mediator.Send(getAnalysisQuery, cancellationToken);
            if (!getUserAnalysisResponse.Success) return BadRequest(ApiResponse.FailResponse(getUserAnalysisResponse.Message, 400));
            return Ok(ApiResponse<GetAnalysisResponse>.SuccessResponse(getUserAnalysisResponse.Data!, getUserAnalysisResponse.Message, 200));
        }
    }
}
