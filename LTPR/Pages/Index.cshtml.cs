using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using LTPR.Data;

namespace LTPR.Pages
{
	public class IndexModel : PageModel
	{

        /*private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void OnGetAsync()
        {
            using (_roleManager)
            {
                bool exists = await _roleManager.RoleExistsAsync("Admin");
                if (!exists)
                {
                    var role = new IdentityRole { Name = "Admin" };
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync("admin@ltpr.it");
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
            
        }*/
    }
}