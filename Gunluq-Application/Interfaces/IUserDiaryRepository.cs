using Gunluq_Domain.DTOs;
using Gunluq_Domain.Entities;
using Gunluq_Domain.Enums;

namespace Gunluq_Application.Interfaces
{
    public interface IUserDiaryRepository
    {
        /// <summary>
        /// Günlüğü oluşturma işlemini yapar
        /// </summary>
        /// <param name="userDiary">Kullanıcı günlüğü nesnesi</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Eklenen UserDiary nesnesini döner</returns>
        Task<UserDiary> AddUserDiaryAsync(UserDiary userDiary, CancellationToken cancellationToken);

        /// <summary>
        /// Parametredeki UserDiary nesnesini güncelleme işlemini yapar
        /// </summary>
        /// <param name="userDiary">Güncellenecek günlük nesnesi</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Güncellenenen UserDiary nesnesini döner</returns>
        Task<UserDiary> UpdateUserDiaryAsync(UserDiary userDiary, CancellationToken cancellationToken);

        /// <summary>
        /// UserDiaryId'ye ait olan kullanıcı günlüğünü siler
        /// </summary>
        /// <param name="userDiaryId">UserDiaryId'sine ait olan kullanıcı günlüğünü siler</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Silme durumuna göre True - False döner</returns>
        Task<bool> DeleteAsync(Guid userDiaryId, CancellationToken cancellationToken);

        /// <summary>
        /// Tüm UserDiary'leri döner
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserDiary döner</returns>
        Task<List<UserDiary>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Tüm aktif olan UserDiary'leri döner
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserDiary döner</returns>
        Task<List<UserDiary>> GetAllActiveAsync(CancellationToken cancellationToken);

        /// <summary>
        /// UserId'ye ait olan UserDiary'leri döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserDiary döner</returns>
        Task<List<UserDiary>> GetAllUserDiaryByUserIdAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Feel'e göre tüm UserDiary'leri döner
        /// </summary>
        /// <param name="feel">His durumu</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserDiary döner</returns>
        Task<List<UserDiary>> GetAllUserDiaryByFeelAsync(Feel feel, CancellationToken cancellationToken);

        /// <summary>
        /// DiaryTag'e göre tüm UserDiary'leri döner
        /// </summary>
        /// <param name="diaryTag">Hangi sınıfta olduğu</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserDiary döner</returns>
        Task<List<UserDiary>> GetAllUserDiaryByDiaryTagAsync(DiaryTag diaryTag, CancellationToken cancellationToken);

        /// <summary>
        /// UserId'ye ait olan içerisinde bulunulan günün UserDiary'sini getirir
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>UserDiary döner</returns>
        Task<UserDiary?> GetUserDiaryInDayAsync(Guid userId, CancellationToken cancellationToken);


        /// <summary>
        /// UserDiaryId ve UserId'ye ait olan UserDiary nesnesini döner
        /// </summary>
        /// <param name="userDiaryId">Kullanıcı günlüğü Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>UserDiary döner</returns>
        Task<UserDiary?> GetUserDiaryByIdAsync(Guid userDiaryId, CancellationToken cancellationToken);

        /// <summary>
        /// Kullanıcının aktif günlük sayısını döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> GetTotalDiaryCountAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Kullanıcının ortalama His durumunu döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<double> GetAverageFeelAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// En çok hangi konu ile günlük yazıldığını döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MostUsedTagInfo?> GetMostUsedTagAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Kullanıcının hangi konuda kaç tane günlük yazdığını döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<TagCountsInfo>> GetTagCountsAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Kullanıcının en mutlu olduğu konuyu ve ortalamasını döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BestTagInfo?> GetBestTagAsync(Guid userId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Kullanıcının en mutsuz olduğu konuyu ve ortalamasını döner
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<WorstTagInfo?> GetWorstTagInfoAsync(Guid userId, CancellationToken cancellationToken);
    }
}
