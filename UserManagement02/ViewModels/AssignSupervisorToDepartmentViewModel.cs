using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UserManagement02.ViewModels;

public class AssignSupervisorToDepartmentViewModel
{
    public int TraineeId { get; set; }
    public string FullName { get; set; }

    [Display(Name = "الإدارة")]
    public int SelectedDepartmentId { get; set; }
    public int DepartmentId { get; set; }


    [Display(Name = "المشرف")]
    [Required]
    public int SelectedSupervisorId { get; set; }

    public IEnumerable<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
    public IEnumerable<SelectListItem> Supervisors { get; set; } = new List<SelectListItem>();
}


