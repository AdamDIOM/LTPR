using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.MenuAtRestaurant
{
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DetailsModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

      public tblMenuAtRestaurant tblMenuAtRestaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblMenuAtRestaurant == null)
            {
                return NotFound();
            }

            var tblmenuatrestaurant = await _context.tblMenuAtRestaurant.FirstOrDefaultAsync(m => m.ID == id);
            if (tblmenuatrestaurant == null)
            {
                return NotFound();
            }
            else 
            {
                tblMenuAtRestaurant = tblmenuatrestaurant;
            }
            return Page();
        }
    }
}
