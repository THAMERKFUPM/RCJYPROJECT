using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UserManagement02.ViewModels;

public class AssignSupervisorToDepartmentViewModel
{
    public int TraineeId { get; set; }
    public string FullName { get; set; }

<<<<<<< HEAD
    [Display(Name = "الإدارة")]
=======
    [Display(Name = "الإدارة")] 
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
    public int SelectedDepartmentId { get; set; }
    public int DepartmentId { get; set; }


<<<<<<< HEAD
    [Display(Name = "المشرف")]
    [Required]
=======
    [Display(Name = "المشرف")] [Required]
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
    public int SelectedSupervisorId { get; set; }

    public IEnumerable<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
    public IEnumerable<SelectListItem> Supervisors { get; set; } = new List<SelectListItem>();
}


<<<<<<< HEAD
=======

>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
