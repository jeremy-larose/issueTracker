using System.ComponentModel;
using System.Web;
using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Shared.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;

namespace BugTracker.Shared.Security
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> userStore) : base(userStore)
        {
            
        }
    }
}