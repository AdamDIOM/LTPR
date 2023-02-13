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

namespace LTPR.Pages.Admin.ImageOnMenuItem
{
    // standard ASP Razor Page CRUD page with added db imports
    public class CreateModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public CreateModel(LTPR.Data.Admin context)
        {
            _context = context;
		}

		public IList<tblMenuItem> tblMenuItem { get; set; } = default!;
		public IList<tblImages> tblImages { get; set; } = default!;
		public IList<tblImageOnMenuItem> tblIOMI { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync()
		{
			if (_context.tblMenuItem != null)
			{
				tblMenuItem = await _context.tblMenuItem.ToListAsync();
			}
			if (_context.tblImages != null)
			{
				tblImages = await _context.tblImages.ToListAsync();
			}
			if (_context.tblImageOnMenuItem != null)
			{
				tblIOMI = await _context.tblImageOnMenuItem.ToListAsync();
			}
			return Page();
        }

        [BindProperty]
        public tblImageOnMenuItem tblImageOnMenuItem { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _context.tblImageOnMenuItem.Add(tblImageOnMenuItem);
                await _context.SaveChangesAsync();
            }
            catch { }

            return RedirectToPage("./Index");
        }
    }
}
