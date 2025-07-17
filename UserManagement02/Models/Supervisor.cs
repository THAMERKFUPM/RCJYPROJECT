namespace UserManagement02.Models
{
    public class Supervisor
    {
        public int SupervisorID { get; set; }

        public string FullName    { get; set; } = null!;
        public string Email       { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public int    DepartmentId { get; set; }

        public Department Department { get; set; } = null!;
    }
}
