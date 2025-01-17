﻿using System;
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
    // standard ASP Razor Page CRUD page
    public class DeleteModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DeleteModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        [BindProperty]
      public tblItemOnMenu tblItemOnMenu { get; set; }
        public IList<tblMenus> tblMenus { get; set; } = default!;
        public IList<tblMenuItem> tblMenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblItemOnMenu == null)
            {
                return NotFound();
            }


            if (_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();
            }
            if (_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tblItemOnMenu == null)
            {
                return NotFound();
            }
            var tblitemonmenu = await _context.tblItemOnMenu.FindAsync(id);

            if (tblitemonmenu != null)
            {
                tblItemOnMenu = tblitemonmenu;
                _context.tblItemOnMenu.Remove(tblItemOnMenu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
