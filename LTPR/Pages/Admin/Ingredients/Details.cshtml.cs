using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.Ingredients
{
    // standard ASP Razor Page CRUD page
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DetailsModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

      public tblIngredients tblIngredients { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblIngredients == null)
            {
                return NotFound();
            }

            var tblingredients = await _context.tblIngredients.FirstOrDefaultAsync(m => m.ID == id);
            if (tblingredients == null)
            {
                return NotFound();
            }
            else 
            {
                tblIngredients = tblingredients;
            }
            return Page();
        }
    }
}
