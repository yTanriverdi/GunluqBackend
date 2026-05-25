using FluentValidation;
using Gunluq_Application.Commands.UserCommands.LoginUser;

namespace Gunluq_WebAPI.Validations.UserValidations.UserCommandValidations
{
    public class UserLoginValidator : AbstractValidator<LoginUserCommand>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("E-Posta zorunludur")
                 .EmailAddress().WithMessage("Geçerli bir E-Posta adresi giriniz");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre zorunludur");
        }
    }
}
