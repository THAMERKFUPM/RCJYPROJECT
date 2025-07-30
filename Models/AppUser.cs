<<<<<<< HEAD
=======
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
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
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
<<<<<<< HEAD
=======
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
        [Required, MaxLength(100)]
        public string? FullName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

<<<<<<< HEAD
=======
<<<<<<< HEAD
        // ← this is your Password property
        [Required, MinLength(6), MaxLength(256)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string? University { get; set; }

        public string? Role { get; set; }
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
      
        [Required]
        public string? UniversityName { get; set; }

        
<<<<<<< HEAD
=======
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8

        [Required]
        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
<<<<<<< HEAD
}
=======
<<<<<<< HEAD
}
=======
}
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
