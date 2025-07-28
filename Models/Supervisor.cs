<<<<<<< HEAD
using UserManagement02.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Supervisor
{
    [Column("Id")]
    public int Id { get; set; }
    [Column("SupervisorID")]
    public int SupervisorID { get; set; }

    [Column("Departments")]
    public string Departments { get; set; } 

    [Column("FullName")]
    public string FullName { get; set; }

    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
=======
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
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
