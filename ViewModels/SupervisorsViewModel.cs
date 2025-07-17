using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManagement02.ViewModels;

public class SupervisorsViewModel
{
    public int SupervisorID { get; set; }
    public int Id { get; set; }
    [Required] public string FullName { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    public string PhoneNumber { get; set; }

    [Required] public string Department { get; set; }
    public string SelectedDepartmentId   { get; set; }
    public string DepartmentName { get; set; }
    

    // populated by PopulateDepartments(...)

    public IEnumerable<SelectListItem> Departments { get; set; }
    


}