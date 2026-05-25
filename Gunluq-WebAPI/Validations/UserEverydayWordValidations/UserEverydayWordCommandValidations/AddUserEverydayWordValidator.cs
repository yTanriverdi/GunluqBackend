using FluentValidation;
using Gunluq_Application.Commands.UserEverydayWordCommands.AddUserEverydayWord;

namespace Gunluq_WebAPI.Validations.UserEverydayWordValidations.UserEverydayWordCommandValidations
{
    public class AddUserEverydayWordValidator : AbstractValidator<AddUserEverydayWordCommand>
    {
        public AddUserEverydayWordValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Günlük cümleler içeriği zorunludur")
                .MaximumLength(200).WithMessage("Günlük cümleler içeriği 200 karakterden uzun olamaz");
        }
    }
}
