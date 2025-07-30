using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManagement02.ViewModels;

public class TraineeAssignViewModel
{
    
    public int TraineeId { get; set; }

    public string FullName { get; set; }

    [Required]
    public int SelectedDepartmentId { get; set; }

    [Required]
    public int SelectedSupervisorId { get; set; }

    [Display(Name = " «—ÌŒ «·„»«‘—…"), Required]
    public DateTime StartDate { get; set; }

    [Display(Name = " «—ÌŒ «‰ Â«¡ «· œ—Ì»"), Required]
    public DateTime EndDate { get; set; }

    public SelectList Departments { get; set; }

    public SelectList Supervisors { get; set; }

}
