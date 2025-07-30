using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UserManagement02.Models
{
    public class AppUser : IdentityUser<String>

    {
        public AppUser()
        {
           Id = Guid.NewGuid().ToString();
        }


        public int UserID { get; set; }
        [Required, MaxLength(100)]
        public string? FullName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

      
        [Required]
        public string? UniversityName { get; set; }

        

        [Required]
        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}