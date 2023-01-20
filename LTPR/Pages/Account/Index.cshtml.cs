using LTPR.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace LTPR.Pages.Account
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }



        [BindProperty]
        public string Email { get; set; }

        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByNameAsync(Email);
            if(user != null)
            {
                return RedirectToPage("Login", new { email = Email });
            }
            else
            {
                return RedirectToPage("Register", new { email = Email });
            }
        }
    }
}
