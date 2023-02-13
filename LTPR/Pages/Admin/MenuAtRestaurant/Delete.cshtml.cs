using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.MenuAtRestaurant
{
    // standard ASP Razor Page CRUD page
    public class DeleteModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DeleteModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        [BindProperty]
      public tblMenuAtRestaurant tblMenuAtRestaurant { get; set; }
        public IList<tblRestaurants> tblRestaurants { get; set; } = default!;
        public IList<tblMenus> tblMenus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblMenuAtRestaurant == null)
            {
                return NotFound();
            }


            if (_context.tblRestaurants != null)
            {
                tblRestaurants = await _context.tblRestaurants.ToListAsync();
            }
            if (_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();
            }

            var tblmenuatrestaurant = await _context.tblMenuAtRestaurant.FirstOrDefaultAsync(m => m.ID == id);

            if (tblmenuatrestaurant == null)
            {
                return NotFound();
            }
            else 
            {
                tblMenuAtRestaurant = tblmenuatrestaurant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tblMenuAtRestaurant == null)
            {
                return NotFound();
            }
            var tblmenuatrestaurant = await _context.tblMenuAtRestaurant.FindAsync(id);

            if (tblmenuatrestaurant != null)
            {
                tblMenuAtRestaurant = tblmenuatrestaurant;
                _context.tblMenuAtRestaurant.Remove(tblMenuAtRestaurant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
