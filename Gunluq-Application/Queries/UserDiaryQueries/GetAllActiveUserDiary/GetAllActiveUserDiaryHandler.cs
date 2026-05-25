using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAllActiveUserDiary
{
    public class GetAllActiveUserDiaryHandler : IRequestHandler<GetAllActiveUserDiaryQuery, ApplicationResponse<List<GetAllActiveUserDiaryResponse>>>  
    {
        private readonly IUserDiaryRepository _userDiaryRepository;

        public GetAllActiveUserDiaryHandler(IUserDiaryRepository userDiaryRepository)
        {
            _userDiaryRepository = userDiaryRepository;
        }

        public async Task<ApplicationResponse<List<GetAllActiveUserDiaryResponse>>> Handle(GetAllActiveUserDiaryQuery getAllActiveUserDiaryQuery, CancellationToken cancellationToken)
        {
            List<UserDiary> userDiaries = await _userDiaryRepository.GetAllActiveAsync(cancellationToken);
            if(!userDiaries.Any()) return ApplicationResponse<List<GetAllActiveUserDiaryResponse>>.Fail(UserDiaryMessages.UserDiariesNotFound);

            List<GetAllActiveUserDiaryResponse> getAllActiveUserDiaryResponses = userDiaries.Select(x => new GetAllActiveUserDiaryResponse 
            {
                Id = x!.Id,
                UserId = x.UserId,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                DiaryTag = x.DiaryTag,
                Feel = x.Feel,
                Status = x.Status
            }).ToList();

            return ApplicationResponse<List<GetAllActiveUserDiaryResponse>>.Ok(getAllActiveUserDiaryResponses, UserDiaryMessages.UserDiariesFound);

        }
    }
}
