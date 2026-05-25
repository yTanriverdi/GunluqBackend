using FluentValidation;
using Gunluq_Application.Commands.UserDiaryCommands.DeleteUserDiary;

namespace Gunluq_WebAPI.Validations.UserDiaryValidations.UserDiaryCommandValidations
{
    public class DeleteUserDiaryValidator : AbstractValidator<DeleteUserDiaryCommand>
    {
        public DeleteUserDiaryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");

            RuleFor(x => x.UserDiaryId)
                .NotEmpty().WithMessage("Kullanıcı günlüğü Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı günlüğü Id girilmelidir");
        }
    }
}
