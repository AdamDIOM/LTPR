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

namespace LTPR.Pages.Admin.MenuItem
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
        public tblMenuItem tblMenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblMenuItem == null)
            {
                return NotFound();
            }

            var tblmenuitem =  await _context.tblMenuItem.FirstOrDefaultAsync(m => m.ID == id);
            if (tblmenuitem == null)
            {
                return NotFound();
            }
            tblMenuItem = tblmenuitem;
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

            _context.Attach(tblMenuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblMenuItemExists(tblMenuItem.ID))
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

        private bool tblMenuItemExists(int id)
        {
          return _context.tblMenuItem.Any(e => e.ID == id);
        }
    }
}
