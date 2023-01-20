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
    public class DeleteModel : PageModel
    {

        private readonly UserManager<ApplicationUser> _userManager;
        public string user;
        public DeleteModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
            var result = await _userManager.DeleteAsync(user);

            return RedirectToPage("./Index");
        }
    }
}
