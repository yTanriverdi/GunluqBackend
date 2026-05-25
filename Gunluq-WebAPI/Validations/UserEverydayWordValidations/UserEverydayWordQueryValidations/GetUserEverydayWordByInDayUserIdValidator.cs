using FluentValidation;
using Gunluq_Application.Queries.UserEverydayWordQueries.GetUserEverydayWordByInDayUserId;

namespace Gunluq_WebAPI.Validations.UserEverydayWordValidations.UserEverydayWordQueryValidations
{
    public class GetUserEverydayWordByInDayUserIdValidator : AbstractValidator<GetUserEverydayWordByInDayUserIdQuery>
    {
        public GetUserEverydayWordByInDayUserIdValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
        }
    }
}
