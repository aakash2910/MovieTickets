﻿using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
