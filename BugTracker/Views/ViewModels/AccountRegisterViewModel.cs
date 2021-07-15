﻿using System.ComponentModel.DataAnnotations;

namespace BugTracker.Views.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required, EmailAddress] 
        public string Email { get; set; }
        
        [Required]
        [StringLength( 100, MinimumLength = 6, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Password { get; set; }
        
        [Display(Name = "Confirm Password")]
        [Compare( "Password", ErrorMessage = "The password fields must match.")]
        public string ConfirmPassword { get; set; }
    }
}