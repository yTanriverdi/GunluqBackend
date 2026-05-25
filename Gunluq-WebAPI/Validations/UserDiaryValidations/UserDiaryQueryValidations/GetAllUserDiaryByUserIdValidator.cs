using FluentValidation;
using Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByUserId;

namespace Gunluq_WebAPI.Validations.UserDiaryValidations.UserDiaryQueryValidations
{
    public class GetAllUserDiaryByUserIdValidator : AbstractValidator<GetAllUserDiaryByUserIdQuery>
    {
        public GetAllUserDiaryByUserIdValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
        }
    }
}
