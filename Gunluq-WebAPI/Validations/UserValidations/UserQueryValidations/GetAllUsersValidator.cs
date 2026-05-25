using FluentValidation;
using Gunluq_Application.Queries.UserQueries.GetAllUsers;

namespace Gunluq_WebAPI.Validations.UserValidations.UserQueryValidations
{
    public class GetAllUsersValidator : AbstractValidator<GetAllUsersQuery>
    {
        public GetAllUsersValidator()
        {
            
        }
    }
}
