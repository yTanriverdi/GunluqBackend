using FluentValidation;
using Gunluq_Application.Commands.UserNoteCommands.AddUserNote;

namespace Gunluq_WebAPI.Validations.UserNoteValidations.UserNoteCommandValidations
{
    public class AddUserNoteValidator : AbstractValidator<AddUserNoteCommand>
    {
        public AddUserNoteValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Not içeriği zorunludur")
                .MaximumLength(500).WithMessage("Not 500 karakterden uzun olamaz"); 
        }
    }
}
