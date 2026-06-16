using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Commands.UserNoteCommands.AddUserNote;
using Gunluq_Application.Commands.UserNoteCommands.DeleteUserNote;
using Gunluq_Application.Commands.UserNoteCommands.UpdateUserNote;
using Gunluq_Application.Queries.UserNoteQueries.GetAllUserNote;
using Gunluq_Application.Queries.UserNoteQueries.GetAllUserNoteByUserId;
using Gunluq_WebAPI.ResponseApi;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunluq_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserNoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPost("AddUserNote")]
        public async Task<IActionResult> AddUserNote([FromBody] AddUserNoteCommand addUserNoteCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<AddUserNoteResponse> addUserNoteResponse = await _mediator.Send(addUserNoteCommand, cancellationToken);
            if (!addUserNoteResponse.Success) return BadRequest(ApiResponse.FailResponse(addUserNoteResponse.Message, 400));
            return Ok(ApiResponse<AddUserNoteResponse>.SuccessResponse(addUserNoteResponse.Data!, addUserNoteResponse.Message, 201));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPut("DeleteUserNote")]
        public async Task<IActionResult> DeleteUserNote([FromBody] DeleteUserNoteCommand deleteUserNoteCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<DeleteUserNoteResponse> deleteUserNoteResponse = await _mediator.Send(deleteUserNoteCommand, cancellationToken);
            if (!deleteUserNoteResponse.Success) return BadRequest(ApiResponse.FailResponse(deleteUserNoteResponse.Message, 400));
            return Ok(ApiResponse<DeleteUserNoteResponse>.SuccessResponse(deleteUserNoteResponse.Data!, deleteUserNoteResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpPut("UpdateUserNote")]
        public async Task<IActionResult> UpdateUserNote([FromBody] UpdateUserNoteCommand updateUserNoteCommand, CancellationToken cancellationToken)
        {
            ApplicationResponse<UpdateUserNoteResponse> updateUserNoteResponse = await _mediator.Send(updateUserNoteCommand, cancellationToken);
            if (!updateUserNoteResponse.Success) return BadRequest(ApiResponse.FailResponse(updateUserNoteResponse.Message, 400));
            return Ok(ApiResponse<UpdateUserNoteResponse>.SuccessResponse(updateUserNoteResponse.Data!, updateUserNoteResponse.Message, 200));
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("GetAllUserNoteByUserId")]
        public async Task<IActionResult> GetAllUserNoteByUserId([FromQuery] GetAllUserNoteByUserIdQuery getAllUserNoteByUserIdQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUserNoteByUserIdResponse>> getAllUserNoteByUserIdResponse = await _mediator.Send(getAllUserNoteByUserIdQuery, cancellationToken);
            if (!getAllUserNoteByUserIdResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserNoteByUserIdResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUserNoteByUserIdResponse>>.SuccessResponse(getAllUserNoteByUserIdResponse.Data!, getAllUserNoteByUserIdResponse.Message, 200));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetAllUserNote")]
        public async Task<IActionResult> GetAllUserNote([FromQuery] GetAllUserNoteQuery getAllUserNoteQuery, CancellationToken cancellationToken)
        {
            ApplicationResponse<List<GetAllUserNoteResponse>> getAllUserNoteResponse = await _mediator.Send(getAllUserNoteQuery, cancellationToken);
            if (!getAllUserNoteResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserNoteResponse.Message, 400));
            return Ok(ApiResponse<List<GetAllUserNoteResponse>>.SuccessResponse(getAllUserNoteResponse.Data!, getAllUserNoteResponse.Message, 200));
        }


        //[Authorize(Policy = "UserOrAdmin")]
        //[HttpGet("GetUserNoteByUserId")]
        //public async Task<IActionResult> GetUserNoteByUserId([FromQuery] GetAllUserNoteByUserIdQuery getAllUserNoteByUserIdQuery, CancellationToken cancellationToken)
        //{
        //    ApplicationResponse<List<GetAllUserNoteByUserIdResponse>> getAllUserNoteByUserIdResponse = await _mediator.Send(getAllUserNoteByUserIdQuery, cancellationToken);
        //    if (!getAllUserNoteByUserIdResponse.Success) return BadRequest(ApiResponse.FailResponse(getAllUserNoteByUserIdResponse.Message, 400));
        //    return Ok(ApiResponse<List<GetAllUserNoteByUserIdResponse>>.SuccessResponse(getAllUserNoteByUserIdResponse.Data!, getAllUserNoteByUserIdResponse.Message, 200));
        //}
    }
}
