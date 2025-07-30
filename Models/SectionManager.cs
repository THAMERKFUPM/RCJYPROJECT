<<<<<<< HEAD
namespace UserManagement02.Models
{
    public class SectionManager
    {
        public int SectionManagerId { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
=======
namespace UserManagement02.Models;

public class SectionManager
{
    public int SectionManagerId { get; set; }

    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
}