using FluentValidation;
using Gunluq_Application.Commands.UserCommands.AddUser;

namespace Gunluq_WebAPI.Validations.UserValidations.UserCommandValidations
{
    public class UserCreateValidator : AbstractValidator<AddUserCommand>
    {
        public UserCreateValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-Posta zorunludur")
                .EmailAddress().WithMessage("Geçerli bir E-Posta adresi giriniz");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre zorunludur")
                .MinimumLength(5).WithMessage("Şifre en az 5 karakter uzunluğunda olabilir")
                .MaximumLength(30).WithMessage("Şifre en fazla 30 karakter uzunluğunda olabilir");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim zorunludur")
                .MinimumLength(3).WithMessage("İsim en az 3 karakter uzunluğunda olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("İsim yalnızca harf içermelidir");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad zorunludur")
                .MinimumLength(2).WithMessage("Soyad en az 2 karakter uzunluğunda olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("Soyad yalnızca harf içermelidir");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı zorunludur")
                .MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakter uzunluğunda olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("Kullanıcı adı yalnızca harf içermelidir");
        }
    }
}
