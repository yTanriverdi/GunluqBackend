using Gunluq_Domain.Entities;

namespace Gunluq_Domain.DTOs
{
    public class LoginUserInfo
    {
        public User User { get; set; } = default!;

        public int DiaryCount { get; set; }

        public int NoteCount { get; set; }

        public int EverydayWordCount { get; set; }
    }
}
