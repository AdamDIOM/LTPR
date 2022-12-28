using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.ImageOnMenuItem
{
    public class DeleteModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DeleteModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        [BindProperty]
      public tblImageOnMenuItem tblImageOnMenuItem { get; set; }
        public IList<tblMenuItem> tblMenuItem { get; set; } = default!;
        public IList<tblImages> tblImages { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblImageOnMenuItem == null)
            {
                return NotFound();
            }


			if (_context.tblMenuItem != null)
			{
				tblMenuItem = await _context.tblMenuItem.ToListAsync();
			}
			if (_context.tblImages != null)
			{
				tblImages = await _context.tblImages.ToListAsync();
			}

			var tblimageonmenuitem = await _context.tblImageOnMenuItem.FirstOrDefaultAsync(m => m.ID == id);

            if (tblimageonmenuitem == null)
            {
                return NotFound();
            }
            else 
            {
                tblImageOnMenuItem = tblimageonmenuitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tblImageOnMenuItem == null)
            {
                return NotFound();
            }
            var tblimageonmenuitem = await _context.tblImageOnMenuItem.FindAsync(id);

            if (tblimageonmenuitem != null)
            {
                tblImageOnMenuItem = tblimageonmenuitem;
                _context.tblImageOnMenuItem.Remove(tblImageOnMenuItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
