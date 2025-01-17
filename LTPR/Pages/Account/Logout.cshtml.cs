using LTPR.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTPR.Pages.Account
{
    public class LogoutModel : PageModel
    {
		private readonly SignInManager<ApplicationUser> _signInManager;
        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
    
        public async Task<IActionResult> OnGetAsync()
        {
            // runs SignInManager sign out code and then returns user to homepage
            await _signInManager.SignOutAsync();
            
		    return RedirectToPage("/Index");
        }
    }
}
