using Gunluq_Domain.Enums;

namespace Gunluq_Application.Queries.UserEverydayWordQueries.GetAllEverydayWordByInDay
{
    public sealed class GetAllUserEverydayWordByInDayResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string Content { get; set; }
        public required Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
