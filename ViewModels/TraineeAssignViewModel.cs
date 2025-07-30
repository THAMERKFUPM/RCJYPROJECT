<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManagement02.ViewModels;

public class TraineeAssignViewModel
{
    
    public int TraineeId { get; set; }
<<<<<<< HEAD
=======
<<<<<<< HEAD
    public string FullName { get; set; }
    public int SelectedDepartmentId { get; set; }
    public IEnumerable<SelectListItem> Departments { get; set; }
    public int SelectedSupervisorId { get; set; }
    public IEnumerable<SelectListItem> Supervisors { get; set; }
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8

    public string FullName { get; set; }

    [Required]
    public int SelectedDepartmentId { get; set; }

    [Required]
    public int SelectedSupervisorId { get; set; }

<<<<<<< HEAD
    [Required, Display(Name = "ÊÇÑíÎ ÇáãÈÇÔÑÉ")]
    public DateTime StartDate { get; set; }

    public SelectList Departments { get; set; }

    public SelectList Supervisors { get; set; }

=======
    public SelectList Departments { get; set; }

    public SelectList Supervisor { get; set; }
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
}
