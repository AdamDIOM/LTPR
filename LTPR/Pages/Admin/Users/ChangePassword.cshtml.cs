using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;
using Microsoft.AspNetCore.Identity;

namespace LTPR.Pages.Admin.Users
{
    public class ChangePasswordModel : PageModel
    {

        [BindProperty]
        public Models.RegistrationModel RegInput { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public string user;
        public ChangePasswordModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IActionResult> OnGetAsync(string? UserName)
        {
            if(UserName != null)
            {
                user = UserName;
            }
            else
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? UserName)
        {
            if (UserName == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, RegInput.Password);
            }

            return RedirectToPage("./Index");
        }
    }
}
