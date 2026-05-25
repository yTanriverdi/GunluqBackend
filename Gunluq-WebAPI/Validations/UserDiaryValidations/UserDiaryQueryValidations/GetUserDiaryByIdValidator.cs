using FluentValidation;
using Gunluq_Application.Queries.UserDiaryQueries.GetUserDiaryById;

namespace Gunluq_WebAPI.Validations.UserDiaryValidations.UserDiaryQueryValidations
{
    public class GetUserDiaryByIdValidator : AbstractValidator<GetUserDiaryByIdQuery>
    {
        public GetUserDiaryByIdValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");

            RuleFor(x => x.UserDiaryId)
               .NotEmpty().WithMessage("Kullanıcı günlüğü Id zorunludur")
               .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı günlüğü Id girilmelidir");
        }
    }
}
