using FluentValidation;
using Gunluq_Application.Queries.UserEverydayWordQueries.GetUserEverydayWordById;

namespace Gunluq_WebAPI.Validations.UserEverydayWordValidations.UserEverydayWordQueryValidations
{
    public class GetUserEverydayWordByIdValidator : AbstractValidator<GetUserEverydayWordByIdQuery>
    {
        public GetUserEverydayWordByIdValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");

            RuleFor(x => x.UserEverydayWordId)
                .NotEmpty().WithMessage("Günlük cümleler Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir günlük cümleler Id girilmelidir");
        }
    }
}
