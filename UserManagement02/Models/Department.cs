namespace UserManagement02.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; } = null!;

        public int? SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }

        public ICollection<Trainee>? Trainees { get; set; } = new List<Trainee>();
        public ICollection<SectionManager>? SectionManager { get; set; } = new List<SectionManager>();
    }
}