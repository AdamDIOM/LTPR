using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DetailsModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

      public tblRestaurants tblRestaurants { get; set; }


        public IList<tblMenus> tblMenus { get; set; } = default!;
        public IList<tblMenuAtRestaurant> tblMenuAtRestaurant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblRestaurants == null)
            {
                return NotFound();
            }


            if (_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();
            }
            if (_context.tblMenuAtRestaurant != null)
            {
                tblMenuAtRestaurant = await _context.tblMenuAtRestaurant.ToListAsync();
            }

            var tblrestaurants = await _context.tblRestaurants.FirstOrDefaultAsync(m => m.ID == id);
            if (tblrestaurants == null)
            {
                return NotFound();
            }
            else 
            {
                tblRestaurants = tblrestaurants;
            }
            return Page();

        }
    }
}
