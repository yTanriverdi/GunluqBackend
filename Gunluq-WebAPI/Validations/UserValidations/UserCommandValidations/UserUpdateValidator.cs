using FluentValidation;
using Gunluq_Application.Commands.UserCommands.UpdateUser;

namespace Gunluq_WebAPI.Validations.UserValidations.UserCommandValidations
{
    public class UserUpdateValidator : AbstractValidator<UpdateUserCommand>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta zorunludur")
                .EmailAddress().WithMessage("Geçerli bir E-posta giriniz");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim zorunludur")
                .MinimumLength(3).WithMessage("İsim en az 3 karakter uzunluğunda olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("İsim yalnızca harf içermelidir");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad zorunludur")
                .MinimumLength(3).WithMessage("Soyad en az 3 karakter uzunluğunda olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("Soyad yalnızca harf içermelidir");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı zorunludur")
                .MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakter uzunluğunda olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("Kullanıcı adı yalnızca harf içermelidir");
        }
    }
}
