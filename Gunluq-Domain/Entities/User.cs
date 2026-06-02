using Gunluq_Domain.BaseEntities;
using Gunluq_Domain.Enums;

namespace Gunluq_Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Role = Role.User;
            UserDiaries = new List<UserDiary>();
            UserNotes = new List<UserNote>();
            UserEverydayWords = new List<UserEverydayWord>();
        }
        public required string Email { get; set; } = default!;
        public required string UserName { get; set; } = default!;
        public required string Password { get; set; } = default!;
        public required string FirstName { get; set; } = default!;
        public required string LastName { get; set; } = default!;
        public DateTime? BannedUntil { get; set; }
        public bool IsBanned => BannedUntil.HasValue && BannedUntil > DateTime.UtcNow;
        public Role Role { get; set; }
        public string EncryptedDek { get; set; } = default!;
        public byte[] Salt { get; set; } = default!;
        public string UserCode { get; set; } = default!;

        // NAVIGATION PROPERTIES
        public ICollection<UserDiary> UserDiaries { get; set; }
        public ICollection<UserNote> UserNotes { get; set; }
        public ICollection<UserEverydayWord> UserEverydayWords { get; set;}


    }
}
