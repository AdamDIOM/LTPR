using LTPR.Data;
using LTPR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTPR.Pages.Account
{
    public class LoginModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string email { get; set; }
		[BindProperty(SupportsGet = true)]
		public string ReturnUrl { get; set; }
		[BindProperty]
        public LogonModel LogonInput { get; set; }
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
            // checks to see whether there was an email passed as parameter, if not sets it to blank string to ensure no error
            if(email == null)
            {
                email = "";
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // uses SignInManager to see if user and password is a match.. If not, the page is reloaded for another attempt
                var result = await _signInManager.PasswordSignInAsync(LogonInput.Email, LogonInput.Password, false, false);
                if (result.Succeeded)
                {
                    // if there is no specified return url, return to homepage, otherwise it attempts to redirect to the given url or given url index page
                    if(ReturnUrl == null)
                    {
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        try
                        {
                            return Redirect(ReturnUrl);
                        }
                        catch
                        {
							return Redirect(ReturnUrl + "/Index");
						}
                        
                    }
                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Logon Attempt");
                    return Page();
                }
            }
            return Page();
        }
    }
}
