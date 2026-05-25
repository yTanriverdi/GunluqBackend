using FluentValidation;
using Gunluq_Application.Commands.UserCommands.ChangePassword;

namespace Gunluq_WebAPI.Validations.UserValidations.UserCommandValidations
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Şifre zorunludur")
                .MinimumLength(5).WithMessage("Şifre en az 5 karakter uzunluğunda olabilir")
                .MaximumLength(30).WithMessage("Şifre en fazla 30 karakter uzunluğunda olabilir");

            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Şifre zorunludur");
        }
    }
}
