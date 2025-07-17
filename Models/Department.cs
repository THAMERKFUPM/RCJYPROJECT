public class Department
{
    public int    Id   { get; set; }
    public string Name { get; set; } = null!;

          public ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();
}