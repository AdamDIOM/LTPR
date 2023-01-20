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

        [BindProperty]
        public string CurrentPassword { get; set; }

        [BindProperty]
        public Models.RegistrationModel RegInput { get; set; }

        public ProfileModel(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            
        }
        public void OnGet()
        {
            userName = _userManager.GetUserName(User);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if(await _userManager.CheckPasswordAsync(user, CurrentPassword))
            {
                await _userManager.ChangePasswordAsync(user, CurrentPassword, RegInput.Password);
                return Page();
            }
            else
            {
                return Page();
            }
            
        }
    }
}
