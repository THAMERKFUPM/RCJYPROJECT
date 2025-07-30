﻿using System.ComponentModel.DataAnnotations;

namespace UserManagement02.ViewModels
{
    public class TraineeLoginViewModel
    {
        [Required, EmailAddress, Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [Display(Name = "تذكرني؟")]
        public bool RememberMe { get; set; }
    }
}
