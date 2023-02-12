using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using LTPR.Data;
using System.Security.Policy;
using LTPR.Models;
using Microsoft.EntityFrameworkCore;

namespace LTPR.Pages.Account
{
    public class ProfileModel : PageModel
    {


        public string userName;
        public UserManager<ApplicationUser> userManager;
        private readonly LTPR.Data.Admin _context;

        [BindProperty]
        public string CurrentPassword { get; set; }

        [BindProperty]
        public Models.RegistrationModel RegInput { get; set; }

        // lists of database tables required
        public IList<tblSales> tblSales { get; set; }
        public IList<tblItemsOnSale> tblItemsOnSale { get; set; }
        public IList<tblMenuItem> tblMenuItem { get; set; }

        public ProfileModel(
            UserManager<ApplicationUser> um, Data.Admin context)
        {
            userManager = um;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            userName = userManager.GetUserName(User);
            if(_context.tblSales != null)
            {
                tblSales = await _context.tblSales.ToListAsync();
            }
            if(_context.tblItemsOnSale != null)
            {
                tblItemsOnSale = await _context.tblItemsOnSale.ToListAsync();
            }
            if(_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // if user enters correct current password, change their password to the new password
            var user = await userManager.GetUserAsync(User);
            if(await userManager.CheckPasswordAsync(user, CurrentPassword))
            {
                await userManager.ChangePasswordAsync(user, CurrentPassword, RegInput.Password);
                return Page();
            }
            else
            {
                return Page();
            }
            
        }
    }
}
