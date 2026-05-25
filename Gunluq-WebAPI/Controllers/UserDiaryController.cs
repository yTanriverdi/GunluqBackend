using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Commands.UserDiaryCommands.AddUserDiary;
using Gunluq_Application.Commands.UserDiaryCommands.DeleteUserDiary;
using Gunluq_Application.Commands.UserDiaryCommands.UpdateUserDiary;
using Gunluq_Application.Queries.UserDiaryQueries.GetAllActiveUserDiary;
using Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiary;
using Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByDiaryTag;
using Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByFeel;
using Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByUserId;
using Gunluq_Application.Queries.UserDiaryQueries.GetUserDiaryById;
using Gunluq_Application.Queries.UserDiaryQueries.GetUserDiaryInDay;
using Gunluq_WebAPI.ResponseApi;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunluq_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDiaryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserDiaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPost("AddUserDiary")]
        public async Task<IActionResult> AddUserDiary([FromBody] AddUserDiaryCommand addUserDiaryCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<AddUserDiaryResponse> addUserDiaryResponse = await _mediator.Send(addUserDiaryCommand, cancellationToken);
            if (!addUserDiaryResponse.Success) return BadRequest(ApiResponse.FailResponse(addUserDiaryResponse.Message, 400));
            return Ok(ApiResponse<AddUserDiaryResponse>.SuccessResponse(addUserDiaryResponse.Data!, addUserDiaryResponse.Message, 201));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPut("DeleteUserDiary")]
        public async Task<IActionResult> DeleteUserDiary([FromBody] DeleteUserDiaryCommand deleteUserDiaryCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<DeleteUserDiaryResponse> deleteUserDiaryResponse = await _mediator.Send(deleteUserDiaryCommand, cancellationToken);
            if (!deleteUserDiaryResponse.Success) return BadRequest(ApiResponse.FailResponse(deleteUserDiaryResponse.Message, 400));
            return Ok(ApiResponse<DeleteUserDiaryResponse>.SuccessResponse(deleteUserDiaryResponse.Data!, deleteUserDiaryResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPut("UpdateUserDiary")]
        public async Task<IActionResult> UpdateUserDiary([FromBody] UpdateUserDiaryCommand updateUserDiaryCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<UpdateUserDiaryResponse> updateUserDiaryResponse = await _mediator.Send(updateUserDiaryCommand, cancellationToken);
            if (!updateUserDiaryResponse.Success) return BadRequest(ApiResponse.FailResponse(updateUserDiaryResponse.Message, 400));
            return Ok(ApiResponse<UpdateUserDiaryResponse>.SuccessResponse(updateUserDiaryResponse.Data!, updateUserDiaryResponse.Message, 200));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetAllActiveUserDiary")]
        public async Task<IActionResult> GetAllActiveUserDiary(CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllActiveUserDiaryResponse>> getAllActiveUserDiaryResponse = await _mediator.Send(new GetAllActiveUserDiaryQuery(), cancellationToken);
            if (!getAllActiveUserDiaryResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllActiveUserDiaryResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllActiveUserDiaryResponse>>.SuccessResponse(getAllActiveUserDiaryResponse.Data!, getAllActiveUserDiaryResponse.Message, 200));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetAllUserDiaryByDiaryTag")]
        public async Task<IActionResult> GetAllUserDiaryByDiaryTag([FromQuery] GetAllUserDiaryByDiaryTagQuery getAllUserDiaryByDiaryTagQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUserDiaryByDiaryTagResponse>> getAllUserDiaryByDiaryTagResponse = await _mediator.Send(getAllUserDiaryByDiaryTagQuery, cancellationToken);
            if (!getAllUserDiaryByDiaryTagResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserDiaryByDiaryTagResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUserDiaryByDiaryTagResponse>>.SuccessResponse(getAllUserDiaryByDiaryTagResponse.Data!, getAllUserDiaryByDiaryTagResponse.Message, 200));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetAllUserDiaryByFeel")]
        public async Task<IActionResult> GetAllUserDiaryByFeel([FromQuery] GetAllUserDiaryByFeelQuery getAllUserDiaryByFeelQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUserDiaryByFeelResponse>> getAllUserDiaryByFeelResponse = await _mediator.Send(getAllUserDiaryByFeelQuery, cancellationToken);
            if (!getAllUserDiaryByFeelResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserDiaryByFeelResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUserDiaryByFeelResponse>>.SuccessResponse(getAllUserDiaryByFeelResponse.Data!, getAllUserDiaryByFeelResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetAllUserDiaryByUserId")]
        public async Task<IActionResult> GetAllUserDiaryByUserId([FromQuery] GetAllUserDiaryByUserIdQuery getAllUserDiaryByUserIdQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUserDiaryByUserIdResponse>> getAllUserDiaryByUserIdResponse = await _mediator.Send(getAllUserDiaryByUserIdQuery, cancellationToken);
            if (!getAllUserDiaryByUserIdResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserDiaryByUserIdResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUserDiaryByUserIdResponse>>.SuccessResponse(getAllUserDiaryByUserIdResponse.Data!, getAllUserDiaryByUserIdResponse.Message, 200));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetAllUserDiary")]
        public async Task<IActionResult> GetAllUserDiary(CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUserDiaryResponse>> getAllUserDiaryResponse = await _mediator.Send(new GetAllUserDiaryQuery(), cancellationToken);
            if (!getAllUserDiaryResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserDiaryResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUserDiaryResponse>>.SuccessResponse(getAllUserDiaryResponse.Data!, getAllUserDiaryResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetUserDiaryById")]
        public async Task<IActionResult> GetUserDiaryByUserId([FromQuery] GetUserDiaryByIdQuery getUserDiaryByIdQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<GetUserDiaryByIdResponse> getUserDiaryByIdResponse = await _mediator.Send(getUserDiaryByIdQuery, cancellationToken);
            if (!getUserDiaryByIdResponse.Success) return BadRequest(ApiResponse.FailResponse(getUserDiaryByIdResponse.Message, 400));
            return Ok(ApiResponse<GetUserDiaryByIdResponse>.SuccessResponse(getUserDiaryByIdResponse.Data!, getUserDiaryByIdResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetUserDiaryInDay")]
        public async Task<IActionResult> GetUserDiaryInDay([FromQuery] GetUserDiaryInDayQuery getUserDiaryInDayQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<GetUserDiaryInDayResponse> getUserDiaryInDayResponse = await _mediator.Send(getUserDiaryInDayQuery, cancellationToken);
            if (!getUserDiaryInDayResponse.Success) return BadRequest(ApiResponse.FailResponse(getUserDiaryInDayResponse.Message, 400));
            return Ok(ApiResponse<GetUserDiaryInDayResponse>.SuccessResponse(getUserDiaryInDayResponse.Data!, getUserDiaryInDayResponse.Message, 200));
        }
    }
}
