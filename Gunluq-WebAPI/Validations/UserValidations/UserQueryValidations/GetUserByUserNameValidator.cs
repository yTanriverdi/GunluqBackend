using FluentValidation;
using Gunluq_Application.Queries.UserQueries.GetUserByUserName;

namespace Gunluq_WebAPI.Validations.UserValidations.UserQueryValidations
{
    public class GetUserByUserNameValidator : AbstractValidator<GetUserByUserNameQuery>
    {
        public GetUserByUserNameValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı zorunludur")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("Kullanıcı adı yalnızca harf içermelidir");
        }
    }
}
