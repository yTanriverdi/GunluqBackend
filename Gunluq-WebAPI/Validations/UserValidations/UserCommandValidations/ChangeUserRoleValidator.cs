using FluentValidation;
using Gunluq_Application.Commands.UserCommands.ChangeUserRole;

namespace Gunluq_WebAPI.Validations.UserValidations.UserCommandValidations
{
    public class ChangeUserRoleValidator : AbstractValidator<ChangeUserRoleCommand>
    {
        public ChangeUserRoleValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
        }
    }
}
