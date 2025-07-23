using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagement02.ViewModels
{
    public class SupervisorViewModel
    {
        public int SupervisorId { get; set; }

        [Required, Display(Name="الاسم")]
        public string SupervisorFullName { get; set; } = null!;

        [Required, EmailAddress, Display(Name="البريد")]
        public string Email { get; set; } = null!;

        [Required, RegularExpression(@"^\+?\d{8,15}$", ErrorMessage="صيغة هاتف غير صحيحة")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage="يجب اختيار إدارة"), Display(Name="الإدارة")]
        public int SelectedDepartmentId { get; set; }
        public string? Department   { get; set; }


        public List<SelectListItem> Departments { get; set; }
            = new List<SelectListItem>();
        
    }
}
