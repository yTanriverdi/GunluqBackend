using FluentValidation;
using Gunluq_Application.Commands.UserEverydayWordCommands.DeleteUserEverydayWord;

namespace Gunluq_WebAPI.Validations.UserEverydayWordValidations.UserEverydayWordCommandValidations
{
    public class DeleteUserEverydayWordValidator : AbstractValidator<DeleteUserEverydayWordCommand>
    {
        public DeleteUserEverydayWordValidator()
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
