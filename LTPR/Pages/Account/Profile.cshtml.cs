using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using LTPR.Data;
using System.Security.Policy;

namespace LTPR.Pages.Account
{
    public class ProfileModel : PageModel
    {


        public string userName;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileModel(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            
        }
        public void OnGet()
        {
            userName = _userManager.GetUserName(User);
        }
    }
}
