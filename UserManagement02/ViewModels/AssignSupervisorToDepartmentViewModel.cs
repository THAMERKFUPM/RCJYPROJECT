using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UserManagement02.ViewModels;

public class AssignSupervisorToDepartmentViewModel
{
    [Display(Name = "الإدارة")]
    public int SelectedDepartmentId { get; set; }

    [Display(Name = "المشرف")]
    public int SelectedSupervisorId { get; set; }

    public SelectList Departments { get; set; }
    public SelectList Supervisors { get; set; }
}