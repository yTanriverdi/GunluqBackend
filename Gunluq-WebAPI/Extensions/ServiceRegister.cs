using Gunluq_Application.DiarySecurity;
using Gunluq_Application.Interfaces;
using Gunluq_Infrastructure.Repositories;

namespace Gunluq_WebAPI.Extensions
{
    public static class ServiceRegister
    {

        /// <summary>
        /// Tüm servislerin kaydını yapar Program.cs içerisine eklemeliyim
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDiaryRepository, UserDiaryRepository>();
            services.AddScoped<IUserEverydayWordRepository, UserEverydayWordRepository>();
            services.AddScoped<IUserNoteRepository, UserNoteRepository>();
            services.AddScoped<UserDiaryCrypto>();
            return services;
        }
    }
}
