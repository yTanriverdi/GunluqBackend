using FluentValidation;
using Gunluq_Application.Queries.UserQueries.GetUserById;

namespace Gunluq_WebAPI.Validations.UserValidations.UserQueryValidations
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
        }
    }
}
