using Gunluq_Application.ApplicationResponse;
using Gunluq_Application.Interfaces;
using Gunluq_Application.ResponseMessages;
using Gunluq_Domain.DTOs;
using Gunluq_Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunluq_Application.Queries.UserDiaryQueries.GetAnalysis
{
    public class GetAnalysisHandler : IRequestHandler<GetAnalysisQuery, ApplicationResponse<GetAnalysisResponse>>
    {
        private readonly IUserDiaryRepository _userDiaryRepository;
        private readonly IUserRepository _userRepository;

        public GetAnalysisHandler(IUserDiaryRepository userDiaryRepository, IUserRepository userRepository)
        {
            _userDiaryRepository = userDiaryRepository;
            _userRepository = userRepository;
        }

        public async Task<ApplicationResponse<GetAnalysisResponse>> Handle(GetAnalysisQuery request, CancellationToken cancellationToken)
        {
            User? foundUser = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
            if (foundUser is null) return ApplicationResponse<GetAnalysisResponse>.Fail(UserMessages.UserNotFound);

            double averageFeel = await _userDiaryRepository.GetAverageFeelAsync(request.UserId, cancellationToken);
            int totalDiaryCount = await _userDiaryRepository.GetTotalDiaryCountAsync(request.UserId, cancellationToken);
            BestTagInfo? bestTagInfo = await _userDiaryRepository.GetBestTagAsync(request.UserId, cancellationToken);
            WorstTagInfo? worstTagInfo = await _userDiaryRepository.GetWorstTagInfoAsync(request.UserId, cancellationToken);
            MostUsedTagInfo? mostUsedTagInfo = await _userDiaryRepository.GetMostUsedTagAsync(request.UserId, cancellationToken);
            List<TagCountsInfo> tagCountsInfo = await _userDiaryRepository.GetTagCountsAsync(request.UserId, cancellationToken);

            AnalysisInfo analysisInfo = new AnalysisInfo
            {
                TotalDiaryCount = totalDiaryCount,
                AverageFeel = averageFeel,
                BestTagInfo = bestTagInfo,
                WorstTagInfo = worstTagInfo,
                MostUsedTagInfo = mostUsedTagInfo,
                TagCountsInfo = tagCountsInfo
            };
            return ApplicationResponse<GetAnalysisResponse>.Ok(new GetAnalysisResponse { AnalysisInfo = analysisInfo }, "Kullanıcının analizi başarıyla döndü");
        }
    }
}
