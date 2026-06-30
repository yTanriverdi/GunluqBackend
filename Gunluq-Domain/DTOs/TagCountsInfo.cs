using Gunluq_Domain.Enums;

namespace Gunluq_Domain.DTOs
{
    public class TagCountsInfo
    {
        public required DiaryTag DiaryTag { get; set; }
        public double AverageFeel { get; set; }
        public int Count { get; set; }
    }
}
