namespace UserManagement02.Models;

public class Trainee
{
    public int TraineeId     { get; set; }
    public string FullName   { get; set; }
    public string Email      { get; set; }
    public string University { get; set; }

    public string PhoneNumber{ get; set; }
    public int DepartmentId  { get; set; }
    public int SupervisorId  { get; set; }
    public bool IsActive     { get; set; } = true;
    public DateTime CreatedAt{ get; set; } = DateTime.Now;
}