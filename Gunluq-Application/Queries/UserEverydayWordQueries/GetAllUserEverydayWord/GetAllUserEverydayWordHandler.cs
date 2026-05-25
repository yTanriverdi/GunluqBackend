using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.Entities;
using MediatR;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetAllUserEverydayWord
{
    public class GetAllUserEverydayWordHandler : IRequestHandler<GetAllUserEverydayWordQuery, ApplicationResponse<List<GetAllUserEverydayWordResponse>>>
    {
        private readonly IUserEverydayWordRepository _userEverydayWordRepository;

        public GetAllUserEverydayWordHandler(IUserEverydayWordRepository userEverydayWordRepository)
        {
            _userEverydayWordRepository = userEverydayWordRepository;
        }

        public async Task<ApplicationResponse<List<GetAllUserEverydayWordResponse>>> Handle(GetAllUserEverydayWordQuery getAllUserEverydayWordQuery, CancellationToken cancellationToken)
        {
            List<UserEverydayWord> everydayWords = await _userEverydayWordRepository.GetAllEverydayWordByInDayAsync(cancellationToken);
            if (!everydayWords.Any()) return ApplicationResponse<List<GetAllUserEverydayWordResponse>>.Fail(UserEverydayWordMessages.UserEverydayWordsNotFound);

            List<GetAllUserEverydayWordResponse> getAllUserEverydayWordResponses = everydayWords.Select(x => new GetAllUserEverydayWordResponse
            {
                Id = x.Id,
                UserId = x.UserId,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                Status = x.Status
            }).ToList();

            return ApplicationResponse<List<GetAllUserEverydayWordResponse>>.Ok(getAllUserEverydayWordResponses, UserEverydayWordMessages.UserEverydayWordsFound);
        }
    }
}
