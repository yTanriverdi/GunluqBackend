using FluentValidation;
using Gunluq_Application.Commands.UserEverydayWordCommands.UpdateEverydayWord;

namespace Gunluq_WebAPI.Validations.UserEverydayWordValidations.UserEverydayWordCommandValidations
{
    public class UpdateUserEverydayWordValidator : AbstractValidator<UpdateUserEverydayWordCommand>
    {
        public UpdateUserEverydayWordValidator()
        {
            RuleFor(x => x.UserId)
               .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
               .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
            
            RuleFor(x => x.UserEverydayWordId)
               .NotEmpty().WithMessage("Günlük cümleler Id zorunludur")
               .NotEqual(Guid.Empty).WithMessage("Geçerli bir günlük cümleler Id girilmelidir");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Günlük cümleler içeriği zorunludur")
                .MaximumLength(200).WithMessage("Günlük cümleler içeriği 200 karakterden uzun olamaz");
        }
    }
}
