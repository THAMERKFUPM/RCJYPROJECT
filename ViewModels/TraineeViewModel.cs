<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Mvc.Rendering;
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
namespace UserManagement02.ViewModels;

public class TraineeViewModel
{
<<<<<<< HEAD
    public int TraineeId     { get; set; }
    public string FullName   { get; set; }
    public string Email      { get; set; }
    public string PhoneNumber{ get; set; }
    public string University { get; set; }

    public int DepartmentId  { get; set; }
    public int SupervisorId  { get; set; }
    public bool IsActive     { get; set; }
    public DateTime CreatedAt{ get; set; }
}
=======
    public int TraineeId     { get; set; } 

    public string FullName   { get; set; }
    public string Email      { get; set; }
    public string PhoneNumber{ get; set; }
    public string? UniversityName { get; set; }
    public string? Major {get; set; }
    
    public string? DepartmentName   { get; set; }
    public string? SupervisorFullName { get; set; }

    public int   SelectedDepartmentId  { get; set; }    
    public int   SelectedSupervisorId  { get; set; }    
    
    public int DepartmentId  { get; set; }
    public IEnumerable<SelectListItem>? Department { get; set; }

    public int SupervisorId  { get; set; }
    public IEnumerable<SelectListItem>? Supervisor { get; set; }

    public bool IsActive     { get; set; }
    public DateTime CreatedAt{ get; set; }
    
    public SelectList? Departments  { get; set; }
}
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
