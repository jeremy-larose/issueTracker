using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using BugTracker.Models;
using BugTracker.Shared.Security;
using BugTracker.Views.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace BugTracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationSignInManager _signInManager;
        private readonly IAuthenticationManager _authenticationManager;
        
        public AccountController( ApplicationUserManager userManager, ApplicationSignInManager signInManager, IAuthenticationManager authenticationManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
        }
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(AccountRegisterViewModel viewModel )
        {
            // If the ModelState is valid...
            if (ModelState.IsValid)
            {
                // Instantiate a User object
                var user = new User() {UserName = viewModel.Email, Email = viewModel.Email};

                // Create the user
                var result = await _userManager.CreateAsync(user, viewModel.Password);

                // If the user was successfully created...
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    
                    // Sign-in the user and redirect them to the web app's Home page
                    return RedirectToAction("Index", "Entries");
                }

                // If there were errors...
                foreach (var error in result.Errors)
                {
                    // Add model errors
                    ModelState.AddModelError("", error);
                }

            }

            return View( viewModel );
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(AccountSignInViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            
            // TODO Sign-In the user
            var result = await _signInManager.PasswordSignInAsync(
                viewModel.Email, viewModel.Password, viewModel.RememberMe, shouldLockout: false);
            
            // Check the result
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Entries");
                case SignInStatus.Failure:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(viewModel);
                case SignInStatus.LockedOut:
                case SignInStatus.RequiresVerification:
                    throw new NotImplementedException( "Identity feature not yet implemented.");
                default: 
                    throw new Exception( "Unexpected Microsoft.AspNet.Identity.Owin.SignInStatus enum value: " + result );
            }
        }
        
        [HttpPost]
        public ActionResult SignOut()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Entries");
        }
    }
}