using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Menus
{
    public class DeleteModel : PageModel
    {
        private readonly LTPR.Data.LTPRContext _context;

        public DeleteModel(LTPR.Data.LTPRContext context)
        {
            _context = context;
        }

        [BindProperty]
      public tblMenus tblMenus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblMenus == null)
            {
                return NotFound();
            }

            var tblmenus = await _context.tblMenus.FirstOrDefaultAsync(m => m.ID == id);

            if (tblmenus == null)
            {
                return NotFound();
            }
            else 
            {
                tblMenus = tblmenus;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tblMenus == null)
            {
                return NotFound();
            }
            var tblmenus = await _context.tblMenus.FindAsync(id);

            if (tblmenus != null)
            {
                tblMenus = tblmenus;
                _context.tblMenus.Remove(tblMenus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
