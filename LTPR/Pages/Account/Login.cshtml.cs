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
        public Models.LogonModel LogonInput { get; set; }
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
            if(email == null)
            {
                email = "";
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(LogonInput.Email, LogonInput.Password, false, false);
                if (result.Succeeded)
                {
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
