using FluentValidation;
using Gunluq_Application.Queries.UserQueries.GetUserByEmail;

namespace Gunluq_WebAPI.Validations.UserValidations.UserQueryValidations
{
    public class GetUserByEmailValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta zorunludur")
                .EmailAddress().WithMessage("Geçerli bir E-posta adresi giriniz");
        }
    }
}
