using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByDiaryTag
{
    public class GetAllUserDiaryByDiaryTagHandler : IRequestHandler<GetAllUserDiaryByDiaryTagQuery, ApplicationResponse<List<GetAllUserDiaryByDiaryTagResponse>>>
    {
        private readonly IUserDiaryRepository _userDiaryRepository;

        public GetAllUserDiaryByDiaryTagHandler(IUserDiaryRepository userDiaryRepository)
        {
            _userDiaryRepository = userDiaryRepository;
        }
        
        public async Task<ApplicationResponse<List<GetAllUserDiaryByDiaryTagResponse>>> Handle(GetAllUserDiaryByDiaryTagQuery getAllUserDiaryByDiaryTagQuery, CancellationToken cancellationToken)
        {

            List<UserDiary> userDiaries = await _userDiaryRepository.GetAllUserDiaryByDiaryTagAsync(getAllUserDiaryByDiaryTagQuery.DiaryTag, cancellationToken);
            if(!userDiaries.Any()) return ApplicationResponse<List<GetAllUserDiaryByDiaryTagResponse>>.Fail(UserDiaryMessages.UserDiariesNotFound);

            List<GetAllUserDiaryByDiaryTagResponse> getAllUserDiaryByDiaryTagResponse = userDiaries.Select(x => new GetAllUserDiaryByDiaryTagResponse
            {
                Id = x.Id,
                UserId = x.UserId,
                Content = x.Content,
                Feel = x.Feel,
                DiaryTag = x.DiaryTag,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                Status = x.Status
            }).ToList();
            return ApplicationResponse<List<GetAllUserDiaryByDiaryTagResponse>>.Ok(getAllUserDiaryByDiaryTagResponse, UserDiaryMessages.UserDiariesFound);
        }
    }
}
