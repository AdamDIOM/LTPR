using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.Images
{
    public class DeleteModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DeleteModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        [BindProperty]
      public tblImages tblImages { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblImages == null)
            {
                return NotFound();
            }

            var tblimages = await _context.tblImages.FirstOrDefaultAsync(m => m.ID == id);

            if (tblimages == null)
            {
                return NotFound();
            }
            else 
            {
                tblImages = tblimages;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tblImages == null)
            {
                return NotFound();
            }
            var tblimages = await _context.tblImages.FindAsync(id);

            if (tblimages != null)
            {
                tblImages = tblimages;
                _context.tblImages.Remove(tblImages);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
