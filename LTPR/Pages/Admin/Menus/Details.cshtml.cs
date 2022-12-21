using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.Menus
{
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DetailsModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

      public tblMenus tblMenus { get; set; }

        public IList<tblMenuItem> tblMenuItem { get; set; } = default!;
        public IList<tblItemOnMenu> tblItemOnMenu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblMenus == null)
            {
                return NotFound();
            }

            if (_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }
            if (_context.tblItemOnMenu != null)
            {
                tblItemOnMenu = await _context.tblItemOnMenu.ToListAsync();
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
    }
}
