using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.IngredientInItem
{
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DetailsModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

      public tblIngredientInItem tblIngredientInItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblIngredientInItem == null)
            {
                return NotFound();
            }

            var tblingredientinitem = await _context.tblIngredientInItem.FirstOrDefaultAsync(m => m.KID == id);
            if (tblingredientinitem == null)
            {
                return NotFound();
            }
            else 
            {
                tblIngredientInItem = tblingredientinitem;
            }
            return Page();
        }
    }
}
