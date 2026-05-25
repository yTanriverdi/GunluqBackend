using System.ComponentModel.DataAnnotations;

namespace Gunluq_Domain.Enums
{
    public enum Feel
    {
        [Display(Name = "Çok Kötü")]
        VeryBad = 1,

        [Display(Name = "Kötü")]
        Bad = 2,

        [Display(Name = "Normal")]
        Neutral = 3,

        [Display(Name = "İyi")]
        Good = 4,

        [Display(Name = "Çok İyi")]
        VeryGood = 5
    }
}
