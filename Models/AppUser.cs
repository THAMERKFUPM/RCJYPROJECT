using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement02.Models
{
    public class AppUser
    {
        [Key]
        public int UserID { get; set; }

        [Required, MaxLength(100)]
        public string? FullName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        // ← this is your Password property
        [Required, MinLength(6), MaxLength(256)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string? University { get; set; }

        public string? Role { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
