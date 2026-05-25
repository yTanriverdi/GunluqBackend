using FluentValidation;
using Gunluq_Application.Queries.UserDiaryQueries.GetAllUserDiaryByDiaryTag;

namespace Gunluq_WebAPI.Validations.UserDiaryValidations.UserDiaryQueryValidations
{
    public class GetAllUserDiaryByDiaryTagValidator : AbstractValidator<GetAllUserDiaryByDiaryTagQuery>
    {
        public GetAllUserDiaryByDiaryTagValidator()
        {
            RuleFor(x => x.DiaryTag).IsInEnum().WithMessage("Geçerli bir etiket seçiniz");
        }
    }
}
