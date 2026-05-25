using FluentValidation;
using Gunluq_Application.Queries.UserEverydayWordQueries.GetAllUserEverydayWordByUserId;

namespace Gunluq_WebAPI.Validations.UserEverydayWordValidations.UserEverydayWordQueryValidations
{
    public class GetAllUserEverydayWordByUserIdValidator : AbstractValidator<GetAllUserEverydayWordByUserIdQuery>
    {
        public GetAllUserEverydayWordByUserIdValidator()
        {
            RuleFor(x => x.UserId)
               .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
               .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
        }
    }
}
