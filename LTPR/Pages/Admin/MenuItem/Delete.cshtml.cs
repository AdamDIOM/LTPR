using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.MenuItem
{
    public class DeleteModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DeleteModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        [BindProperty]
      public tblMenuItem tblMenuItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblMenuItem == null)
            {
                return NotFound();
            }

            var tblmenuitem = await _context.tblMenuItem.FirstOrDefaultAsync(m => m.ID == id);

            if (tblmenuitem == null)
            {
                return NotFound();
            }
            else 
            {
                tblMenuItem = tblmenuitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tblMenuItem == null)
            {
                return NotFound();
            }
            var tblmenuitem = await _context.tblMenuItem.FindAsync(id);

            if (tblmenuitem != null)
            {
                tblMenuItem = tblmenuitem;
                tblMenuItem.Retired = true;
                //_context.tblMenuItem.Remove(tblMenuItem);
                _context.Attach(tblMenuItem).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                } catch { }
            }

            return RedirectToPage("./Index");
        }
    }
}
