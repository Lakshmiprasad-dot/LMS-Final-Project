using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public enum MyIdentityRoleNames
    {

        [Display(Name = "Admin Role")]
        AppAdmin,

        [Display(Name = "User Role")]
        AppUser

    }
}
