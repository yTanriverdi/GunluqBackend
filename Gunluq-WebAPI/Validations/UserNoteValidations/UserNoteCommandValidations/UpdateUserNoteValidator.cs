using FluentValidation;
using Gunluq_Application.Commands.UserNoteCommands.UpdateUserNote;

namespace Gunluq_WebAPI.Validations.UserNoteValidations.UserNoteCommandValidations
{
    public class UpdateUserNoteValidator : AbstractValidator<UpdateUserNoteCommand>
    {
        public UpdateUserNoteValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");

            RuleFor(x => x.UserNoteId)
                .NotEmpty().WithMessage("Not Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir not Id girilmelidir");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Not içeriği zorunludur")
                .MaximumLength(500).WithMessage("Not 500 karakterden uzun olamaz");
        }
    }
}
