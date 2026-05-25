using Gunluq_Domain.Entities;

namespace Gunluq_Application.Interfaces
{
    public interface IUserEverydayWordRepository
    {
        /// <summary>
        /// UserEverydayWord ekleme işlemi yapar
        /// </summary>
        /// <param name="userEverydayWord">Eklenecek UserEverydayWord nesnesi</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Eklenen UserEverydayWord nesnesini döner</returns>
        Task<UserEverydayWord> AddUserEverydayWordAsync(UserEverydayWord userEverydayWord, CancellationToken cancellationToken);

        /// <summary>
        /// UserEverydayWord güncelleme işlemi yapar
        /// </summary>
        /// <param name="userEverydayWord">Eklenecek bilgileri içeren UserEverydayWord nesnesi</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Güncelenen UserEverydayWord nesnesini döner</returns>
        Task<UserEverydayWord> UpdateEverydayWordAsync(UserEverydayWord userEverydayWord, CancellationToken cancellationToken);

        /// <summary>
        /// UserEverydayWordId'ye ait olan UserEverydayWord nesnesini siler
        /// </summary>
        /// <param name="userEverydayWordId">UserEverydayWord Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Başarılı olma durumuna göre True - False döner</returns>
        Task<bool> DeleteEverydayWordAsync(Guid userEverydayWordId, CancellationToken cancellationToken);

        /// <summary>
        /// Tüm UserEverydayWord nesnelerini döner
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserEverydayWord döner</returns>
        Task<List<UserEverydayWord>> GetAllUserEverydayWordAsync(CancellationToken cancellationToken);

        /// <summary>
        /// UserId'ye ait olan o gün içerisindeki UserEverydayWord nesnesini döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>UserEverydayWord nesnesini döner</returns>
        Task<UserEverydayWord?> GetUserEverydayWordByInDayUserIdAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Gün içerisindeki tüm UserEverydayWord nesnelerini döner
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserEverydayWord döner</returns>
        Task<List<UserEverydayWord>> GetAllEverydayWordByInDayAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Kullanıcı Id'ye ait olan tüm UserEverydayWord nesnelerini döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserEverydayWord döner</returns>
        Task<List<UserEverydayWord>> GetAllUserEverydayWordByUserIdAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Id'ye ait olan UserEveryDayWord nesnesini döner
        /// </summary>
        /// <param name="Id">UserEveryDayWord Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>UserEveryDayWord döner</returns>
        Task<UserEverydayWord?> GetUserEverydayWordByIdAsync(Guid Id, CancellationToken cancellationToken);

    }
}
