using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.MenuAtRestaurant
{
    // UNUSED
    // standard ASP Razor Page CRUD page
    public class EditModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public EditModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        [BindProperty]
        public tblMenuAtRestaurant tblMenuAtRestaurant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblMenuAtRestaurant == null)
            {
                return NotFound();
            }

            var tblmenuatrestaurant =  await _context.tblMenuAtRestaurant.FirstOrDefaultAsync(m => m.ID == id);
            if (tblmenuatrestaurant == null)
            {
                return NotFound();
            }
            tblMenuAtRestaurant = tblmenuatrestaurant;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(tblMenuAtRestaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblMenuAtRestaurantExists(tblMenuAtRestaurant.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool tblMenuAtRestaurantExists(int id)
        {
          return _context.tblMenuAtRestaurant.Any(e => e.ID == id);
        }
    }
}
