<<<<<<< HEAD
﻿using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement02.Models
{
    public class AppUser
    {
        [Key]
        public int UserID { get; set; }

=======
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
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
        [Required, MaxLength(100)]
        public string? FullName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

<<<<<<< HEAD
        // ← this is your Password property
        [Required, MinLength(6), MaxLength(256)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string? University { get; set; }

        public string? Role { get; set; }
=======
      
        [Required]
        public string? UniversityName { get; set; }

        
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587

        [Required]
        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
