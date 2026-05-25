using FluentValidation;
using Gunluq_Application.Queries.UserNoteQueries.GetUserNoteByUserId;

namespace Gunluq_WebAPI.Validations.UserNoteValidations.UserNoteQueryValidations
{
    public class GetUserNoteByUserIdValidator : AbstractValidator<GetUserNoteByIdQuery>
    {
        public GetUserNoteByUserIdValidator()
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
