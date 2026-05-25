using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiary
{
    public class GetAllUserDiaryHandler : IRequestHandler<GetAllUserDiaryQuery, ApplicationResponse<List<GetAllUserDiaryResponse>>>
    {
        private readonly IUserDiaryRepository _userDiaryRepository;

        public GetAllUserDiaryHandler(IUserDiaryRepository userDiaryRepository)
        {
            _userDiaryRepository = userDiaryRepository;
        }

        public async Task<ApplicationResponse<List<GetAllUserDiaryResponse>>> Handle(GetAllUserDiaryQuery getAllUserDiaryQuery, CancellationToken cancellationToken)
        {
            List<UserDiary> userDiaries = await _userDiaryRepository.GetAllAsync(cancellationToken);
            if (!userDiaries.Any()) return ApplicationResponse<List<GetAllUserDiaryResponse>>.Fail(UserDiaryMessages.UserDiariesNotFound);
            List<GetAllUserDiaryResponse> getAllUserDiaryResponses = userDiaries.Select(x => new GetAllUserDiaryResponse
            {
                Id = x.Id,
                UserId = x.UserId,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                DiaryTag = x.DiaryTag,
                Feel = x.Feel,
                Status = x.Status
            }).ToList();
            return ApplicationResponse<List<GetAllUserDiaryResponse>>.Ok(getAllUserDiaryResponses, UserDiaryMessages.UserDiariesFound);
        }
    }
}
