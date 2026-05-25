using FluentValidation;
using Gunluq_Application.Queries.UserNoteQueries.GetAllUserNoteByUserId;

namespace Gunluq_WebAPI.Validations.UserNoteValidations.UserNoteQueryValidations
{
    public class GetAllUserNoteByUserIdValidator : AbstractValidator<GetAllUserNoteByUserIdQuery>
    {
        public GetAllUserNoteByUserIdValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Id zorunludur")
                .NotEqual(Guid.Empty).WithMessage("Geçerli bir kullanıcı Id girilmelidir");
        }
    }
}
