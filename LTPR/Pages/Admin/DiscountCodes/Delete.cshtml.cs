using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.DiscountCodes
{
    public class DeleteModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DeleteModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        [BindProperty]
      public tblDiscountCodes tblDiscountCodes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblDiscountCodes == null)
            {
                return NotFound();
            }

            var tbldiscountcodes = await _context.tblDiscountCodes.FirstOrDefaultAsync(m => m.ID == id);

            if (tbldiscountcodes == null)
            {
                return NotFound();
            }
            else 
            {
                tblDiscountCodes = tbldiscountcodes;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tblDiscountCodes == null)
            {
                return NotFound();
            }
            var tbldiscountcodes = await _context.tblDiscountCodes.FindAsync(id);

            if (tbldiscountcodes != null)
            {
                tblDiscountCodes = tbldiscountcodes;
                _context.tblDiscountCodes.Remove(tblDiscountCodes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
