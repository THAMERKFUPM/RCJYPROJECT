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

        [Display(Name = "كلمة المرور")]
        public string Password { get; set; } = "";
        public bool IsActive { get; set; } = true;

        [Display(Name = "تاريخ المباشرة"), Required]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Display(Name = "تاريخ انتهاء التدريب"), Required]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(56);
    }
}
