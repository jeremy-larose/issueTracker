using System.Threading.Tasks;
using BugTracker.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace BugTracker.Shared.Security
{
    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager,
            IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
        
    }
}