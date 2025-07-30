namespace UserManagement02.Models
{
    public class Supervisor
    {
        public int SupervisorId { get; set; }

        public string SupervisorFullName { get; set; } = null!;

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public ICollection<Trainee> Trainee { get; set; } = new List<Trainee>();
    }
}