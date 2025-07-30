namespace UserManagement02.ViewModels;

public class UserViewModel
{
<<<<<<< HEAD
    public string UserID { get; set; } = "";
=======
<<<<<<< HEAD
    public int    UserID      { get; set; }
=======
    public string UserID { get; set; } = "";
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
    public string FullName    { get; set; }
    public string Email       { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    public string Role        { get; set; }
    public string University { get; set; }
    public bool   IsActive    { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}