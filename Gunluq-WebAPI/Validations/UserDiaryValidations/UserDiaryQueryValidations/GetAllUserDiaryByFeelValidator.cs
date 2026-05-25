using FluentValidation;
using Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByFeel;

namespace Gunluq_WebAPI.Validations.UserDiaryValidations.UserDiaryQueryValidations
{
    public class GetAllUserDiaryByFeelValidator : AbstractValidator<GetAllUserDiaryByFeelQuery>
    {
        public GetAllUserDiaryByFeelValidator()
        {
            RuleFor(x => x.Feel)
                .IsInEnum().WithMessage("Geçerli bir duygu seçiniz");
        }
    }
}
