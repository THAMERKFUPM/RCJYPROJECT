namespace UserManagement02.ViewModels;

public class UserViewModel
{
    public string UserID { get; set; } = "";
    public string FullName    { get; set; }
    public string Email       { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    public string Role        { get; set; }
    public string University { get; set; }
    public bool   IsActive    { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}