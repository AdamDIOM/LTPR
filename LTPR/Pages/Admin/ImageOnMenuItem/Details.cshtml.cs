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
    // UNUSED
    // standard ASP Razor Page CRUD page
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DetailsModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

      public tblImageOnMenuItem tblImageOnMenuItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblImageOnMenuItem == null)
            {
                return NotFound();
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
    }
}
