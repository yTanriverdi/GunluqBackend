using FluentValidation;
using Gunluq_Application.Commands.UserCommands.DeleteUser;

namespace Gunluq_WebAPI.Validations.UserValidations.UserCommandValidations
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
        }
    }
}
