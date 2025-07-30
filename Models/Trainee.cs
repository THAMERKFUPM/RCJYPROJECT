<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;

=======
<<<<<<< HEAD
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
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
namespace UserManagement02.Models
{
    public class Trainee
    {
        public int TraineeId { get; set; }

<<<<<<< HEAD
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? UniversityName { get; set; }
        public string? Major { get; set; }
        public string PhoneNumber { get; set; } = null!;
=======
        public string FullName { get; set; } 
        public string Email { get; set; } 
        public string? UniversityName { get; set; }
        public string? Major { get; set; } 
        public string PhoneNumber { get; set; } 
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }

<<<<<<< HEAD
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "تاريخ البدء")]
        public DateTime StartDate { get; set; } = DateTime.Today;
        
        
        
        

    }
=======
        public string? SelectedDepartmentId { get; set; }
        public string? SelectedSupervisorId { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
}