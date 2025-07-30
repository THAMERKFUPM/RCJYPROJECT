using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManagement02.ViewModels;
public class TraineeViewModel
{
    public int? TraineeId { get; set; }

    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? UniversityName { get; set; }
    public string? Major { get; set; }
    public string PhoneNumber { get; set; } = null!;

    public int SelectedDepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty; 

    public int SelectedSupervisorId { get; set; } 
    public string SupervisorFullName { get; set; } = string.Empty; 

    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public IEnumerable<SelectListItem> Departments { get; set; } = Enumerable.Empty<SelectListItem>();
    public IEnumerable<SelectListItem> Supervisors { get; set; } = Enumerable.Empty<SelectListItem>();
}