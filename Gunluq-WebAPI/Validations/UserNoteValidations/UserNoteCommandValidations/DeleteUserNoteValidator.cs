using FluentValidation;
using Gunluq_Application.Commands.UserNoteCommands.DeleteUserNote;

namespace Gunluq_WebAPI.Validations.UserNoteValidations.UserNoteCommandValidations
{
    public class DeleteUserNoteValidator : AbstractValidator<DeleteUserNoteCommand>
    {
        public DeleteUserNoteValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");

            RuleFor(x => x.UserNoteId)
                .NotEmpty().WithMessage("Not Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir not Id girilmelidir");
        }
    }
}
