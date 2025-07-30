<<<<<<< HEAD
=======
<<<<<<< HEAD
public class Department
{
    public int    Id   { get; set; }
    public string Name { get; set; } = null!;

          public ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
namespace UserManagement02.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; } = null!;

        public int? SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }

<<<<<<< HEAD
        public int? SectionManagerId { get; set; }
        public SectionManager? SectionManager { get; set; }

        public ICollection<Trainee>? Trainees { get; set; } = new List<Trainee>();
    }
=======
        public ICollection<Trainee>? Trainee { get; set; } = new List<Trainee>();
        public ICollection<SectionManager>? SectionManager { get; set; } = new List<SectionManager>();
    }
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
}