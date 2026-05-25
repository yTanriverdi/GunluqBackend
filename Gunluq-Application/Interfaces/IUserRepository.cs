
using Gunluq_Domain.Entities;

namespace Gunluq_Application.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Kullanıcı ekleme işlemi yapar
        /// </summary>
        /// <param name="user">Eklenecek kullanıcı nesnesi</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Eklenen User nesnesini döner</returns>
        Task<User> AddUserAsync(User user, CancellationToken cancellationToken);

        /// <summary>
        /// Kullanıcının Role değişimini yapar
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Başarılı olma durumuna göre True - False döner</returns>
        Task<bool> ChangeUserRoleAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// UserId'ye ait olan kullanıcıyı pasif olarak siler
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Başarılı olma durumuna göre True - False döner</returns>
        Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Kullanıcı güncelleme işlemini yapar
        /// </summary>
        /// <param name="user">Güncellenecek bilgileri içeren User nesnesi</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Güncellenen User nesnesini döner</returns>
        Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken);

        /// <summary>
        /// Email'e ait olan kullanıcıyı döner
        /// </summary>
        /// <param name="email">Kullanıcı Emaili</param>
        /// <param name="cancellationToken"></param>
        /// <returns>User nesnesi döner</returns>
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// UserId'ye ait olan kullanıcıyı döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>User nesnesi döner</returns>
        Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// UserName'e ait olan kullanıcıyı döner
        /// </summary>
        /// <param name="userName">Kullanıcı adı</param>
        /// <param name="cancellationToken"></param>
        /// <returns>User nesnesi döner</returns>
        Task<User?> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken);

        /// <summary>
        /// Tüm kullanıcıları döner
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Tüm User nesnelerini döner</returns>
        Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Kullanıcının şifre güncellemesini yapar
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="newPassword">Yeni Şifre</param>
        /// <returns></returns>
        Task<bool> UserPasswordUpdateAsync(Guid userId, string newPassword, CancellationToken cancellationToken);
    }
}
