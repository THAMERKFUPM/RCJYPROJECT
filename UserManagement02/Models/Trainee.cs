namespace UserManagement02.Models
{
    public class Trainee
    {
        public int TraineeId { get; set; }

        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UniversityName { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }

        public string? SelectedDepartmentId { get; set; }
        public string? SelectedSupervisorId { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}