using System.ComponentModel.DataAnnotations;

namespace Gunluq_Domain.Enums
{
    public enum DiaryTag
    {
        [Display(Name = "İş")]
        Work = 1,

        [Display(Name = "Aile")]
        Family = 2,

        [Display(Name = "Arkadaşlar")]
        Friends = 3,

        [Display(Name = "Sağlık")]
        Health = 4,

        [Display(Name = "Spor")]
        Sport = 5,

        [Display(Name = "Eğitim")]
        Study = 6,

        [Display(Name = "Seyahat")]
        Travel = 7,

        [Display(Name = "Ruh Hali")]
        Mood = 8,

        [Display(Name = "Stres")]
        Stress = 9,

        [Display(Name = "Mutluluk")]
        Happiness = 10,

        [Display(Name = "Motivasyon")]
        Motivation = 11,

        [Display(Name = "Kişisel")]
        Personal = 12,

        [Display(Name = "Finans")]
        Finance = 13,

        [Display(Name = "Hobi")]
        Hobby = 14,

        [Display(Name = "İlişki")]
        Relationship = 15
    }
}
