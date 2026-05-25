using Gunluq_Domain.Entities;

namespace Gunluq_Application.Interfaces
{
    public interface IUserNoteRepository
    {
        /// <summary>
        /// UserNote ekleme işlemi yapar
        /// </summary>
        /// <param name="userNote">Eklenecek UserNotes nesnesi</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Eklenen UserNotes nesnesini döner</returns>
        Task<UserNote> AddUserNoteAsync(UserNote userNote, CancellationToken cancellationToken);

        /// <summary>
        /// UserNotes güncelleme işlemi yapar
        /// </summary>
        /// <param name="userNote">Güncelenecek bilgilerle UserNote nesnesi</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Güncellenen UserNote nesnesini döner</returns>
        Task<UserNote> UpdateUserNoteAsync(UserNote userNote, CancellationToken cancellationToken);

        /// <summary>
        /// Tüm UserNote nesnelerini döner
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserNotes döner</returns>
        Task<List<UserNote>> GetAllUserNoteAsnc(CancellationToken cancellationToken);

        /// <summary>
        /// Kullanıcı Id'ye ait olan tüm UserNote nesnelerini döner
        /// </summary>
        /// <param name="userId">Kullanıcı Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List UserNotes döner</returns>
        Task<List<UserNote>> GetAllUserNoteByUserIdAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// UserNoteId'ye ait olan UserNote nesnesini siler
        /// </summary>
        /// <param name="userNoteId">UserNote Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Başarılı olma durumuna göre True - False döner</returns>
        Task<bool> DeleteUserNoteByIdAsync(Guid userNoteId, CancellationToken cancellationToken);

        /// <summary>
        /// UserNoteId'ye ait olan UserNote nesnesini döner
        /// </summary>
        /// <param name="userNoteId">UserNote Id'si</param>
        /// <param name="cancellationToken"></param>
        /// <returns>UserNote döner</returns>
        Task<UserNote?> GetUserNoteByIdAsync(Guid userNoteId, CancellationToken cancellationToken);
    }
}
