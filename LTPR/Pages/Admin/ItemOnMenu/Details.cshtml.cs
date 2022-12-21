using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.ItemOnMenu
{
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DetailsModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

      public tblItemOnMenu tblItemOnMenu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblItemOnMenu == null)
            {
                return NotFound();
            }

            var tblitemonmenu = await _context.tblItemOnMenu.FirstOrDefaultAsync(m => m.ID == id);
            if (tblitemonmenu == null)
            {
                return NotFound();
            }
            else 
            {
                tblItemOnMenu = tblitemonmenu;
            }
            return Page();
        }
    }
}
