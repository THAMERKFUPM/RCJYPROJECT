namespace UserManagement02.Models;

public class SectionManager
{
    public int SectionManagerId { get; set; }

    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}