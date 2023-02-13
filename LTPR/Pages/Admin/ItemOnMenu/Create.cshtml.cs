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

namespace LTPR.Pages.Admin.ItemOnMenu
{
    // standard ASP Razor Page CRUD page
    public class CreateModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public CreateModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        public IList<tblMenus> tblMenus { get; set; } = default!;
        public IList<tblMenuItem> tblMenuItem { get; set; } = default!;
        public IList<tblItemOnMenu> tblIOM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();
            }
            if (_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }
            if (_context.tblItemOnMenu != null)
            {
                tblIOM = await _context.tblItemOnMenu.ToListAsync();
            }
            return Page();
        }

        [BindProperty]
        public tblItemOnMenu tblItemOnMenu { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _context.tblItemOnMenu.Add(tblItemOnMenu);
                await _context.SaveChangesAsync();
            }
            catch { }

            return RedirectToPage("./Index");
        }
    }
}
