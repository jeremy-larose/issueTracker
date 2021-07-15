using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.Owin;

namespace BugTracker.Views.ViewModels
{
    public class AccountSignInViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Display(Name="Remember me?")]
        public bool RememberMe { get; set; }
    }
}