using Gunluq_Domain.Enums;

namespace Gunluq_Domain.DTOs
{
    public class MostUsedTagInfo
    {
        public required DiaryTag DiaryTag { get; set; }
        public int Count { get; set; }
    }
}
