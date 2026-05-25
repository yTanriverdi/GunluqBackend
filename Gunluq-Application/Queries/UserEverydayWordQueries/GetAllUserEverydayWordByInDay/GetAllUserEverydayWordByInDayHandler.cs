using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetAllEverydayWordByInDay
{
    public class GetAllUserEverydayWordByInDayHandler : IRequestHandler<GetAllUserEverydayWordByInDayQuery, ApplicationResponse<List<GetAllUserEverydayWordByInDayResponse>>>
    {
        private readonly IUserEverydayWordRepository _userEverydayWordRepository;

        public GetAllUserEverydayWordByInDayHandler(IUserEverydayWordRepository userEverydayWordRepository)
        {
            _userEverydayWordRepository = userEverydayWordRepository;
        }

        public async Task<ApplicationResponse<List<GetAllUserEverydayWordByInDayResponse>>> Handle(GetAllUserEverydayWordByInDayQuery getAllEverydayWordByInDayQuery, CancellationToken cancellationToken)
        {
            List<UserEverydayWord> everydayWords = await _userEverydayWordRepository.GetAllEverydayWordByInDayAsync(cancellationToken);
            if (!everydayWords.Any()) return ApplicationResponse<List<GetAllUserEverydayWordByInDayResponse>>.Fail(UserEverydayWordMessages.UserEverydayWordsNotFound);

            List<GetAllUserEverydayWordByInDayResponse> getAllUserEverydayWordByInDayResponses = everydayWords.Select(x => new GetAllUserEverydayWordByInDayResponse
            {
                Id = x.Id,
                UserId = x.UserId,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                Status = x.Status
            }).ToList();

            return ApplicationResponse<List<GetAllUserEverydayWordByInDayResponse>>.Ok(getAllUserEverydayWordByInDayResponses, UserEverydayWordMessages.UserEverydayWordsFound);
        }
    }
}
