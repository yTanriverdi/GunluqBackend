using System.ComponentModel.DataAnnotations;

namespace Gunluq_Domain.Enums
{
    public enum Role
    {
        [Display(Name = "Yönetici")]
        Admin = 0,
        [Display(Name = "Kullanıcı")]
        User = 1
    }
}
