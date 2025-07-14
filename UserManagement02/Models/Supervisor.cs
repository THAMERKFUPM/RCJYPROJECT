using UserManagement02.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Supervisor
{
    [Column("Id")]
    public int Id { get; set; }

    [Column("Departments")]
    public string Departments { get; set; } 

    [Column("FullName")]
    public string FullName { get; set; }

    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
