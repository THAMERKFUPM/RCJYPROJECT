using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManagement02.ViewModels;

public class TraineeAssignViewModel
{
    
    public int TraineeId { get; set; }
    public string FullName { get; set; }
    public int SelectedDepartmentId { get; set; }
    public IEnumerable<SelectListItem> Departments { get; set; }
    public int SelectedSupervisorId { get; set; }
    public SelectList Supervisor { get; set; }
}
