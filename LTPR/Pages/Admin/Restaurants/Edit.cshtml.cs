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

namespace LTPR.Pages.Admin.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public EditModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        [BindProperty]
        public tblRestaurants tblRestaurants { get; set; } = default!;
        public IList<tblMenus> tblMenus { get; set; } = default!;
        public IList<tblMenuAtRestaurant> tblMenuAtRestaurant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblRestaurants == null)
            {
                return NotFound();
            }

            if (_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();
            }
            if (_context.tblMenuAtRestaurant != null)
            {
                tblMenuAtRestaurant = await _context.tblMenuAtRestaurant.ToListAsync();
            }

            var tblrestaurants =  await _context.tblRestaurants.FirstOrDefaultAsync(m => m.ID == id);
            if (tblrestaurants == null)
            {
                return NotFound();
            }
            tblRestaurants = tblrestaurants;
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

            _context.Attach(tblRestaurants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblRestaurantsExists(tblRestaurants.ID))
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

        private bool tblRestaurantsExists(int id)
        {
          return _context.tblRestaurants.Any(e => e.ID == id);
        }
    }
}
