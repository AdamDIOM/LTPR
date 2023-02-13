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

namespace LTPR.Pages.Admin.MenuAtRestaurant
{
    // standard ASP Razor Page CRUD page
    public class CreateModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public CreateModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        public IList<tblRestaurants> tblRestaurants { get; set; } = default!;
        public IList<tblMenus> tblMenus { get; set; } = default!;
        public IList<tblMenuAtRestaurant> tblMAR { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.tblRestaurants != null)
            {
                tblRestaurants = await _context.tblRestaurants.ToListAsync();
            }
            if (_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();
            }
            if (_context.tblMenuAtRestaurant != null)
            {
                tblMAR = await _context.tblMenuAtRestaurant.ToListAsync();
            }
            return Page();
        }

        [BindProperty]
        public tblMenuAtRestaurant tblMenuAtRestaurant { get; set; }


            // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
            public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _context.tblMenuAtRestaurant.Add(tblMenuAtRestaurant);
                await _context.SaveChangesAsync();
            }
            catch { }

            return RedirectToPage("./Index");
        }
    }
}
