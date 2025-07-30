using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement02.ViewModels
{

    public class CreateTraineeViewModel
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string UniversityName { get; set; } = string.Empty;

        [Required]
        public string Major { get; set; } = string.Empty;

        [Required, RegularExpression(@"^\+?\d{8,15}$", ErrorMessage = "صيغة هاتف غير صحيحة")]
        public string PhoneNumber { get; set; } = string.Empty;

<<<<<<< HEAD
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; } = "";
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
        public bool IsActive { get; set; } = true;
    }
}
