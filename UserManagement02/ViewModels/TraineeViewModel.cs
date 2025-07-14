namespace UserManagement02.ViewModels;

public class TraineeViewModel
{
    public int TraineeId     { get; set; }
    public string FullName   { get; set; }
    public string Email      { get; set; }
    public string PhoneNumber{ get; set; }
    public int DepartmentId  { get; set; }
    public int SupervisorId  { get; set; }
    public bool IsActive     { get; set; }
    public DateTime CreatedAt{ get; set; }
}
