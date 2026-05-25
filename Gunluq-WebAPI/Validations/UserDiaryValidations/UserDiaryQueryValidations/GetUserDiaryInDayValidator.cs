using FluentValidation;
using Gunluq_Application.Queries.UserDiaryQueries.GetUserDiaryInDay;

namespace Gunluq_WebAPI.Validations.UserDiaryValidations.UserDiaryQueryValidations
{
    public class GetUserDiaryInDayValidator : AbstractValidator<GetUserDiaryInDayQuery>
    {
        public GetUserDiaryInDayValidator()
        {
            RuleFor(x => x.UserId)
               .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
               .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
        }
    }
}
