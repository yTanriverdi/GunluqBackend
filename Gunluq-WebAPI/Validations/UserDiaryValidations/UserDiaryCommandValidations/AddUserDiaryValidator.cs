using FluentValidation;
using Gunluq_Application.Commands.UserDiaryCommands.AddUserDiary;

namespace Gunluq_WebAPI.Validations.UserDiaryValidations.UserDiaryCommandValidations
{
    public class AddUserDiaryValidator : AbstractValidator<AddUserDiaryCommand>
    {
        public AddUserDiaryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");

            RuleFor(x => x.Feel)
                .IsInEnum().WithMessage("Geçerli bir duygu seçiniz");

            RuleFor(x => x.DiaryTag)
                .IsInEnum().WithMessage("Geçerli bir etiket seçiniz");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Günlük içeriği zorunludur")
                .MaximumLength(4000).WithMessage("Günlük içeriği 4000 karakterden uzun olamaz");
        }
    }
}
