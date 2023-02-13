using LTPR.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace LTPR.Pages.Account
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Email == null || Email == "")
            {
                return RedirectToPage();
            }
            // attempts to find user in database, if user exists they are redirected to Login page, otherwise to the Register page. Both pass the entered email address as a parameter to the next page
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
