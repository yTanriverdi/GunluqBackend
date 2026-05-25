using Gunluq_Domain.Entities;
using Gunluq_Domain.Enums;

namespace Gunluq_Application.Queries.UserQueries.GetUserByUserName
{
    public sealed class GetUserByUserNameResponse
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool IsBanned { get; set; }
        public required Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public List<UserNote>? UserNotes { get; set; }
        public List<UserEverydayWord>? UserEverydayWords { get; set; }
        public List<UserDiary>? UserDiaries { get; set; }
    }
}
