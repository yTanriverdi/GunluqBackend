using System.ComponentModel.DataAnnotations;

namespace Gunluq_Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Pasif")]
        Passive = 0,
        [Display(Name = "Aktif")]
        Active = 1,
    }
}
