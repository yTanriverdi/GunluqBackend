using FluentValidation;
using Gunluq_Application.Queries.UserDiaryQueries.GetAnalysis;

namespace Gunluq_WebAPI.Validations.UserDiaryValidations.UserDiaryQueryValidations
{
    public class GetAnalysisValidator : AbstractValidator<GetAnalysisQuery>
    {
        public GetAnalysisValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
        }
    }
}
