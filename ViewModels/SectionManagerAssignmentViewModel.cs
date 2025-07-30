using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManagement02.ViewModels
{
    public class SectionManagerAssignmentViewModel
    {
        [Required(ErrorMessage = "يجب اختيار الإدارة")]
        [Display(Name = "الإدارة")]
        public int SelectedDepartmentId { get; set; }

        [Required(ErrorMessage = "يجب اختيار مشرف التدريب")]
        [Display(Name = "مشرف التدريب")]
        public int SelectedSupervisorId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Supervisors { get; set; }
            = new List<SelectListItem>();
    }
}

