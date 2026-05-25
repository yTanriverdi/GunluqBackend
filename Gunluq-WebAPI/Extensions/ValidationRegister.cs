using FluentValidation;
using FluentValidation.AspNetCore;
using Gunluq_WebAPI.APIAssemblyReference;

namespace Gunluq_WebAPI.Extensions
{
    public static class ValidationRegister
    {
        public static IServiceCollection ValidationRegistration(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(typeof(APIAssembly).Assembly);
            return services;
        }
    }
}
