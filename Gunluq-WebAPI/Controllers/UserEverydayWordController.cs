using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Commands.UserEverydayWordCommands.AddUserEverydayWord;
using Gunluq_Application.Commands.UserEverydayWordCommands.DeleteUserEverydayWord;
using Gunluq_Application.Commands.UserEverydayWordCommands.UpdateEverydayWord;
using Gunluq_Application.Queries.UserEverydayWordQueries.GetAllEverydayWordByInDay;
using Gunluq_Application.Queries.UserEverydayWordQueries.GetAllUserEverydayWord;
using Gunluq_Application.Queries.UserEverydayWordQueries.GetAllUserEverydayWordByUserId;
using Gunluq_Application.Queries.UserEverydayWordQueries.GetUserEverydayWordById;
using Gunluq_Application.Queries.UserEverydayWordQueries.GetUserEverydayWordByInDayUserId;
using Gunluq_WebAPI.ResponseApi;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunluq_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEverydayWordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserEverydayWordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPost("AddUserEveryDayWord")]
        public async Task<IActionResult> AddUserEveryDayWord([FromBody] AddUserEverydayWordCommand addUserEverydayWordCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<AddUserEverydayWordResponse> addUserEverydayWordResponse = await _mediator.Send(addUserEverydayWordCommand, cancellationToken);
            if (!addUserEverydayWordResponse.Success) return BadRequest(ApiResponse.FailResponse(addUserEverydayWordResponse.Message, 400));
            return Ok(ApiResponse<AddUserEverydayWordResponse>.SuccessResponse(addUserEverydayWordResponse.Data!, addUserEverydayWordResponse.Message, 201));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPut("DeleteUserEverydayWord")]
        public async Task<IActionResult> DeleteUserEverydayWord([FromBody] DeleteUserEverydayWordCommand deleteUserEverydayWordCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<DeleteUserEverydayWordResponse> deleteUserEverydayWordResponse = await _mediator.Send(deleteUserEverydayWordCommand, cancellationToken);
            if (!deleteUserEverydayWordResponse.Success) return BadRequest(ApiResponse.FailResponse(deleteUserEverydayWordResponse.Message, 400));
            return Ok(ApiResponse<DeleteUserEverydayWordResponse>.SuccessResponse(deleteUserEverydayWordResponse.Data!, deleteUserEverydayWordResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPut("UpdateUserEverydayWord")]
        public async Task<IActionResult> UpdateUserEverydayWord([FromBody] UpdateUserEverydayWordCommand updateUserEverydayWordCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<UpdateUserEverydayWordResponse> updateUserEverydayWordResponse = await _mediator.Send(updateUserEverydayWordCommand, cancellationToken);
            if (!updateUserEverydayWordResponse.Success) return BadRequest(ApiResponse.FailResponse(updateUserEverydayWordResponse.Message, 400));
            return Ok(ApiResponse<UpdateUserEverydayWordResponse>.SuccessResponse(updateUserEverydayWordResponse.Data!, updateUserEverydayWordResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetAllUserEverydayWordByInDay")]
        public async Task<IActionResult> GetAllUserEverydayWordByInDay(CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUserEverydayWordByInDayResponse>> getAllUserEverydayWordByInDayResponse = await _mediator.Send(new GetAllUserEverydayWordByInDayQuery(), cancellationToken);
            if (!getAllUserEverydayWordByInDayResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserEverydayWordByInDayResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUserEverydayWordByInDayResponse>>.SuccessResponse(getAllUserEverydayWordByInDayResponse.Data!, getAllUserEverydayWordByInDayResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetAllUserEverydayWordByUserId")]
        public async Task<IActionResult> GetAllUserEverydayWordByUserId([FromQuery] GetAllUserEverydayWordByUserIdQuery getAllUserEverydayWordByUserIdQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUserEverydayWordByUserIdResponse>> getAllUserEverydayWordByUserIdResponse = await _mediator.Send(getAllUserEverydayWordByUserIdQuery, cancellationToken);
            if (!getAllUserEverydayWordByUserIdResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserEverydayWordByUserIdResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUserEverydayWordByUserIdResponse>>.SuccessResponse(getAllUserEverydayWordByUserIdResponse.Data!, getAllUserEverydayWordByUserIdResponse.Message, 200));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetAllUserEverydayWord")]
        public async Task<IActionResult> GetAllUserEverydayWord(CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUserEverydayWordResponse>> getAllUserEverydayWordResponse = await _mediator.Send(new GetAllUserEverydayWordQuery(), cancellationToken);
            if (!getAllUserEverydayWordResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserEverydayWordResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUserEverydayWordResponse>>.SuccessResponse(getAllUserEverydayWordResponse.Data!, getAllUserEverydayWordResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetUserEverydayWordById")]
        public async Task<IActionResult> GetUserEverydayWordById([FromQuery] GetUserEverydayWordByIdQuery getAllUserEverydayWordByIdQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<GetUserEverydayWordByIdResponse> getUserEverydayWordByIdResponse = await _mediator.Send(getAllUserEverydayWordByIdQuery, cancellationToken);
            if (!getUserEverydayWordByIdResponse.Success) return BadRequest(ApiResponse.FailResponse(getUserEverydayWordByIdResponse.Message, 400));
            return Ok(ApiResponse<GetUserEverydayWordByIdResponse>.SuccessResponse(getUserEverydayWordByIdResponse.Data!, getUserEverydayWordByIdResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetUserEverydayWordByInDayUserId")]
        public async Task<IActionResult> GetUserEverydayWordByInDayUserId([FromQuery] GetUserEverydayWordByInDayUserIdQuery getUserEverydayWordByInDayUserIdQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<GetUserEverydayWordByInDayUserIdResponse> getUserEverydayWordByInDayUserIdResponse = await _mediator.Send(getUserEverydayWordByInDayUserIdQuery, cancellationToken);
            if (!getUserEverydayWordByInDayUserIdResponse.Success) return BadRequest(ApiResponse.FailResponse(getUserEverydayWordByInDayUserIdResponse.Message, 400));
            return Ok(ApiResponse<GetUserEverydayWordByInDayUserIdResponse>.SuccessResponse(getUserEverydayWordByInDayUserIdResponse.Data!, getUserEverydayWordByInDayUserIdResponse.Message, 200));
        }
    }
}
