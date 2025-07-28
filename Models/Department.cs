<<<<<<< HEAD
public class Department
{
    public int    Id   { get; set; }
    public string Name { get; set; } = null!;

          public ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();
=======
namespace UserManagement02.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; } = null!;

        public int? SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }

        public ICollection<Trainee>? Trainee { get; set; } = new List<Trainee>();
        public ICollection<SectionManager>? SectionManager { get; set; } = new List<SectionManager>();
    }
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
}