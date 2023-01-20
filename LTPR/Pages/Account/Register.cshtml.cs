using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using LTPR.Data;

namespace LTPR.Pages.Account
{
    public class RegisterModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string email { get; set; }

        [BindProperty]
        public Models.RegistrationModel RegInput { get; set; }
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task OnGetAsync()
        {
            bool exists = await _roleManager.RoleExistsAsync("Admin");
            if(!exists)
            {
                var role = new IdentityRole { Name = "Admin" };
                var result = await _roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync("admin@ltpr.it");
                    if(user != null)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    
                }
            }

                if (email == null)
            {
                email = "";
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = RegInput.Email, Email = RegInput.Email };
                var result = await _userManager.CreateAsync(user, RegInput.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
