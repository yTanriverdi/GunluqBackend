namespace Gunluq_Domain.DTOs
{
    public class AnalysisInfo
    {
        public int TotalDiaryCount { get; set; }
        public double AverageFeel { get; set; }
        public MostUsedTagInfo? MostUsedTagInfo { get; set; } = default!;
        public List<TagCountsInfo> TagCountsInfo { get; set; } = default!;
        public WorstTagInfo? WorstTagInfo { get; set;} = default!;
        public BestTagInfo? BestTagInfo { get; set; } = default!;
    }
}
