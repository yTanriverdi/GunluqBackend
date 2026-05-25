using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByFeel
{
    public class GetAllUserDiaryByFeelHandler : IRequestHandler<GetAllUserDiaryByFeelQuery, ApplicationResponse<List<GetAllUserDiaryByFeelResponse>>>
    {
        private readonly IUserDiaryRepository _userDiaryRepository;

        public GetAllUserDiaryByFeelHandler(IUserDiaryRepository userDiaryRepository)
        {
            _userDiaryRepository = userDiaryRepository;
        }

        public async Task<ApplicationResponse<List<GetAllUserDiaryByFeelResponse>>> Handle(GetAllUserDiaryByFeelQuery getAllUserDiaryByFeelQuery, CancellationToken cancellationToken)
        {
            List<UserDiary> userDiaries = await _userDiaryRepository.GetAllUserDiaryByFeelAsync(getAllUserDiaryByFeelQuery.Feel, cancellationToken);
            if (!userDiaries.Any()) return ApplicationResponse<List<GetAllUserDiaryByFeelResponse>>.Fail(UserDiaryMessages.UserDiariesNotFound);

            List<GetAllUserDiaryByFeelResponse> getAllUserDiaryByFeelResponses = userDiaries.Select(x => new GetAllUserDiaryByFeelResponse
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

            return ApplicationResponse<List<GetAllUserDiaryByFeelResponse>>.Ok(getAllUserDiaryByFeelResponses, UserDiaryMessages.UserDiariesFound);
        }
                
    }
}
